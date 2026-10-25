using Nethereum.ABI;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Accounts;
using Nethereum.Contracts;
using Nethereum.Contracts.TransactionHandlers;
using Nethereum.Hex;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.Model;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.Eth.Transactions;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Nethereum.RPC.Eth.DTOs.BlockParameter;
using static Nethereum.Util.UnitConversion;


namespace OX.Tablet.Eths
{
    [Function("transfer", "bool")]
    public class TransferFunction : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public string To { get; set; }

        [Parameter("uint256", "_value", 2)]
        public BigInteger Value { get; set; }
    }

    public class EthereumTransactionBuilder
    {
        /// <summary>
        /// USDT 主网合约地址
        /// </summary>
        public const string usdtContract = "0xdAC17F958D2ee523a2206206994597C13D831ec7";
        private string _nodeUrl;
        private string _privateKey;
        public EthereumTransactionBuilder(string privateKey, string nodeUrl)
        {
            _nodeUrl = nodeUrl;
            _privateKey = privateKey;
        }
        public async Task<(bool result, decimal usdt_balance, decimal ether_balance)> GetEthAndUSDTBalance()
        {
            try
            {
                var chainId = 1;
                var account = new Nethereum.Web3.Accounts.Account(_privateKey, chainId);
                Console.WriteLine("发送方钱包地址: " + account.Address);

                // 公共RPC节点
                var web3 = new Web3(account, _nodeUrl);
                // ========== 查询 ETH 余额 ==========
                BigInteger ethWei = await web3.Eth.GetBalance.SendRequestAsync(account.Address);
                decimal balanceEther = Web3.Convert.FromWei(ethWei);
                Console.WriteLine($"当前ETH余额：{balanceEther} ETH");

                // 获取ERC20服务实例
                var erc20_usdt = web3.Eth.ERC20.GetContractService(usdtContract);
                var decimals = await erc20_usdt.DecimalsQueryAsync();
                // 2. 查询发送方USDT余额
                BigInteger balanceRaw = await erc20_usdt.BalanceOfQueryAsync(account.Address);
                decimal balanceUsdt = Web3.Convert.FromWei(balanceRaw, decimals);
                Console.WriteLine($"当前USDT余额：{balanceUsdt}");
                return (true, balanceUsdt, balanceEther);
            }
            catch
            {
                return (false, 0, 0);
            }
        }
        public async Task<(bool result, int code, string txid)> TransferUSDT(string receiverAddress, decimal transferAmount)
        {
            try
            {
                var chainId = 1;
                var account = new Nethereum.Web3.Accounts.Account(_privateKey, chainId);
                Console.WriteLine("发送方钱包地址: " + account.Address);

                // 公共RPC节点
                var web3 = new Web3(account, _nodeUrl);

                // 获取ERC20服务实例
                var erc20_usdt = web3.Eth.ERC20.GetContractService(usdtContract);
                var decimals = await erc20_usdt.DecimalsQueryAsync();
                // 转为代币最小单位（USDT 6位小数）
                BigInteger transferAmountRaw = Web3.Convert.ToWei(transferAmount, decimals);

                // 调用Transfer，自动签名、广播、等待回执（TransactionManager内部封装）
                var receipt = await erc20_usdt.TransferRequestAndWaitForReceiptAsync(
                    receiverAddress,
                    transferAmountRaw
                );
                Console.WriteLine($"交易哈希 TxHash: {receipt.TransactionHash}");
                Console.WriteLine($"交易是否成功: {receipt.Status.Value == 1}");
                return (receipt.Status.Value == 1, (int)receipt.Status.Value, receipt.TransactionHash);
            }
            catch (Exception ex)
            {
                return (false, int.MinValue, ex.Message);
            }
        }
        public async Task<(bool result,  string txid)> TransferUSDTWithMark(string receiverAddress, decimal transferAmount, byte[] marks)
        {
            try
            {

                var chainId = 1; // ETH主网
                var account = new Nethereum.Web3.Accounts.Account(this._privateKey, chainId);
                // 公共RPC节点
                var web3 = new Web3(account, _nodeUrl);
                // 获取ERC20服务实例
                var erc20_usdt = web3.Eth.ERC20.GetContractService(usdtContract);
                var decimals = await erc20_usdt.DecimalsQueryAsync();
                // 转为代币最小单位（USDT 6位小数）
                BigInteger transferAmountRaw = Web3.Convert.ToWei(transferAmount, decimals);

                // 1.生成transfer标准calldata
                var transferMsg = new TransferFunction
                {
                    To = receiverAddress,
                    Value = transferAmountRaw
                };
                byte[] transferCalldata = transferMsg.GetCallData();

                // 2.把备注文本转UTF8字节，追加到calldata尾部
                //byte[] memoBytes = System.Text.Encoding.UTF8.GetBytes(mark);
                byte[] fullCalldata = new byte[transferCalldata.Length + marks.Length];
                Buffer.BlockCopy(transferCalldata, 0, fullCalldata, 0, transferCalldata.Length);
                Buffer.BlockCopy(marks, 0, fullCalldata, transferCalldata.Length, marks.Length);

                // 3.构造EIP1559交易
                var nonce = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(account.Address, BlockParameterType.pending);
                //var maxPriorityFee = BigInteger.Parse("3000000000");
                //var maxFee = BigInteger.Parse("30000000000");

                // 3. 动态预估 Gas Limit
                var callInput = transferMsg.CreateCallInput(usdtContract);
                callInput.From = account.Address;
                var estimatedGas = await web3.Eth.Transactions.EstimateGas.SendRequestAsync(callInput);
                BigInteger gasLimit = (BigInteger)(estimatedGas.Value * (BigInteger)2); // 留 200% 缓冲

                // 4. 动态查询并计算 Gas Price (EIP-1559)
                var feeHistory = await web3.Eth.FeeHistory.SendRequestAsync(
                    new HexBigInteger(1),
                    BlockParameter.CreateLatest(),
                    new decimal[] { 20.0m }
                );
                BigInteger maxPriorityFeePerGas = UnitConversion.Convert.ToWei(1.5, EthUnit.Gwei);
                BigInteger currentBaseFee = feeHistory.BaseFeePerGas[0].Value;
                BigInteger maxFeePerGas = (currentBaseFee * 2) + maxPriorityFeePerGas;

                // 5. 组装 1559 交易
                var transaction = new Transaction1559(
                    chainId: new HexBigInteger(chainId), // 可通过 await web3.Eth.ChainId.SendRequestAsync() 动态查
                    nonce: nonce.Value,
                    maxPriorityFeePerGas: maxPriorityFeePerGas,
                maxFeePerGas: maxFeePerGas,
                gasLimit: gasLimit,
                    receiverAddress: usdtContract,
                    amount: 0,
                    data: fullCalldata.ToHex(true),
                    accessList: new List<AccessListItem>()
                );

                // 签名
                var signer = new Transaction1559Signer();
                var rawTxHex = signer.SignTransaction(this._privateKey, transaction);

                // 广播
                var txHash = await web3.Eth.Transactions.SendRawTransaction.SendRequestAsync(rawTxHex);
                Console.WriteLine($"TxHash: {txHash}");
                return (true, txHash);
            }
            catch (Exception ex)
            {
                return (false,  ex.Message);
            }
        }

        public async void Test()
        {
            var chainId = 1;
            var account = new Nethereum.Web3.Accounts.Account(_privateKey, chainId);
            Console.WriteLine("发送方钱包地址: " + account.Address);

            // 公共RPC节点
            var web3 = new Web3(account, _nodeUrl);


            string receiverAddress = "";

            // 获取ERC20服务实例
            var erc20_usdt = web3.Eth.ERC20.GetContractService(usdtContract);

            // 1. 查询USDT代币信息（名称、符号、小数位）
            var name = await erc20_usdt.NameQueryAsync();
            var symbol = await erc20_usdt.SymbolQueryAsync();
            var decimals = await erc20_usdt.DecimalsQueryAsync();
            Console.WriteLine($"代币:{name} | 符号:{symbol} | 小数位:{decimals}");

            // 2. 查询发送方USDT余额
            BigInteger balanceRaw = await erc20_usdt.BalanceOfQueryAsync(account.Address);
            decimal balanceHuman = Web3.Convert.FromWei(balanceRaw, decimals);
            Console.WriteLine($"当前USDT余额：{balanceHuman}");

            // ========== 转账：转 1 USDT ==========
            decimal transferAmount = 1m;
            // 转为代币最小单位（USDT 6位小数）
            BigInteger transferAmountRaw = Web3.Convert.ToWei(transferAmount, decimals);

            // 调用Transfer，自动签名、广播、等待回执（TransactionManager内部封装）
            //var receipt = await erc20_usdt.TransferRequestAndWaitForReceiptAsync(
            //    receiverAddress,
            //    transferAmountRaw
            //);

            // 1. 发送已签名的 Raw 交易，获取交易 Hash
            var signedRawTransaction = await BuildDynamicUsdtTransactionAsync(web3, _privateKey, account.Address, receiverAddress, transferAmount);
            string txHash = await web3.Eth.Transactions.SendRawTransaction.SendRequestAsync(signedRawTransaction);

            // 2. 使用 TransactionReceiptService 等待该 Hash 被打包并返回收据
            TransactionReceipt receipt = await web3.Eth.TransactionManager
                .TransactionReceiptService
                .PollForReceiptAsync(txHash);

            // 3. 检查状态（1 为成功，0 为失败）
            if (receipt.Status.Value == 1)
            {
                System.Console.WriteLine($"交易成功！Hash: {receipt.TransactionHash}");
            }

            Console.WriteLine($"交易哈希 TxHash: {receipt.TransactionHash}");
            Console.WriteLine($"交易是否成功: {receipt.Status.Value == 1}");
        }
        // 1. 定义 ERC20 的 transfer 方法

        public async Task<string> BuildDynamicUsdtTransactionAsync(
    Web3 web3,
    string privateKey,
    string senderAddress,
    string recipientAddress,
    decimal usdtAmount)
        {


            // 1. 动态编码 Data
            var transferMessage = new TransferFunction
            {
                To = recipientAddress,
                Value = UnitConversion.Convert.ToWei(usdtAmount, 6)
            };
            string dataHex = transferMessage.GetCallData().ToHex(true);

            // 2. 动态查询 Nonce
            var nonce = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(senderAddress);

            // 3. 动态预估 Gas Limit
            var callInput = transferMessage.CreateCallInput(usdtContract);
            callInput.From = senderAddress;
            var estimatedGas = await web3.Eth.Transactions.EstimateGas.SendRequestAsync(callInput);
            BigInteger gasLimit = (BigInteger)(estimatedGas.Value * (BigInteger)1.2); // 留 20% 缓冲

            // 4. 动态查询并计算 Gas Price (EIP-1559)
            var feeHistory = await web3.Eth.FeeHistory.SendRequestAsync(
                new HexBigInteger(1),
                BlockParameter.CreateLatest(),
                new decimal[] { 20.0m }
            );
            BigInteger maxPriorityFeePerGas = UnitConversion.Convert.ToWei(1.5, EthUnit.Gwei);
            BigInteger currentBaseFee = feeHistory.BaseFeePerGas[0].Value;
            BigInteger maxFeePerGas = (currentBaseFee * 2) + maxPriorityFeePerGas;

            // 5. 组装 1559 交易
            var transaction = new Transaction1559(
                chainId: 1, // 可通过 await web3.Eth.ChainId.SendRequestAsync() 动态查
                nonce: nonce.Value,
                maxPriorityFeePerGas: maxPriorityFeePerGas,
                maxFeePerGas: maxFeePerGas,
                gasLimit: gasLimit,
                receiverAddress: usdtContract,
                amount: 0,
                data: dataHex,
                accessList: new List<AccessListItem>()
            );

            // 6. 离线签名
            var signer = new Transaction1559Signer();
            signer.SignTransaction(privateKey, transaction);

            return transaction.GetRLPEncoded().ToHex(true);
        }


    }
}
