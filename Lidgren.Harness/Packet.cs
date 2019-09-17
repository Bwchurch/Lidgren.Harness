using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidgren.Harness
{
    public class Packet
    {
        public int? PacketID { get; set; }
        public int NetworkID { get; set; }
        public string ActionKey { get; set; }
        public JObject Payload { get; set; }
        public DateTime TimeStamp { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
