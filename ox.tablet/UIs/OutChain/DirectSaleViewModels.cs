using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Drawing;
namespace OX.Tablet.UIs.OutChain
{
    public class AssetViewModel
    {
        public string Name { get; set; }
        public UInt256 AssetId { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
