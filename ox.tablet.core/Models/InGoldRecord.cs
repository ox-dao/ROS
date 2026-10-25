using OX.BMS;
using OX.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OX.Cryptography.ECC;

namespace OX.Tablet
{
    public enum InOutGoldStatus : byte
    {
        [Name("未提交", "Not Submitted")]
        Inited = 1 << 0,
        [Name("已提交", "Submitted")]
        Submitted = 1 << 1,
        [Name("已兑付", "Settled")]
        Settled = 1 << 2
    }
    public class InGoldRecord : ISerializable
    {
        public InOutGoldStatus State;
        public UInt256 EthTxId;
        public ECPoint Buyer;
        public Fixed8 Amount=Fixed8.Zero;
        public uint TimeStamp;
        public virtual int Size => sizeof(InOutGoldStatus) + EthTxId.Size+Buyer.Size+Amount.Size+sizeof(uint);
        public void Deserialize(BinaryReader reader)
        {
            State = (InOutGoldStatus)reader.ReadByte();
            EthTxId = reader.ReadSerializable<UInt256>();
            Amount = reader.ReadSerializable<Fixed8>();
            TimeStamp = reader.ReadUInt32();
        }
        public void Serialize(BinaryWriter writer)
        {
            writer.Write((byte)State);
            writer.Write(EthTxId);
            writer.Write(Amount);
            writer.Write(TimeStamp);
        }
    }
    public class OutGoldRecord : ISerializable
    {
        public UInt256 EthTxId;
        public Fixed8 Amount;
        public uint TimeStamp;
        public virtual int Size =>  EthTxId.Size + Amount.Size + sizeof(uint);
        public void Deserialize(BinaryReader reader)
        {
            EthTxId = reader.ReadSerializable<UInt256>();
            Amount = reader.ReadSerializable<Fixed8>();
            TimeStamp = reader.ReadUInt32();
        }
        public void Serialize(BinaryWriter writer)
        {
            writer.Write(EthTxId);
            writer.Write(Amount);
            writer.Write(TimeStamp);
        }
    }
}
