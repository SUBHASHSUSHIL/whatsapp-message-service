using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsApp_VMS_Service.AppCode;

namespace WhatsApp_VMS_Service.Model
{
    public class WhatsAppModel
    {
        public string APIURL { get; set; } = "https://media.smsgupshup.com/GatewayAPI/rest";
        public string UserId { get; set; } = GlobalModel.WUserId;      //"2000241495";
        public string Password { get; set; } = GlobalModel.WPassword; //  "nB$yvp4U";
        public string Channel { get; set; } = "nB$yvp4U";
        public string AuthSchema { get; set; } = "plain";
        public string Version { get; set; } = "1.1";
        public string Format { get; set; } = "text";
        public string Method { get; set; } = "SendMessage";
        public string SendTo { get; set; }
        public string MessageType { get; set; } = "DATA_TEXT";
        public string Message { get; set; }
        public string MediaURL { get; set; }
        public string DataEncoding { get; set; } = "text";
        public bool IsHSM { get; set; } = false;
    }
}
