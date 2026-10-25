using OX.Network.P2P.Payloads;
using System;
using OX.Tablet.Flash;
namespace OX.Tablet.FlashMessages
{
    public class MulticastChatboxInfo
    {
        public Tuple<UInt256, MulticastTalkLineValue> TP { get; set; }
        public OXAccount LocalAccount { get; set; }
        public byte[] Keys { get; set; }
        public string LocalAddress { get; set; }      
        public string TalkLabel { get; set; }
        public string ChatPlaceholder = "Please enter a message...";
        public byte[] Attachment { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentType { get; set; }
        public string GetLabel()
        {
            var label= TP.Item2.Label;
            if (TP.Item2.Level > 0)
            {
                label = $"*{label}";
            }
            return label;
        }
    }
}
