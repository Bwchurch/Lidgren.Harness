using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lidgren.Harness
{
    public class Server
    {
        public Server()
        {
            NetPeerConfiguration config = new NetPeerConfiguration("SpaceFighter");
            config.Port = 5000;
            config.BroadcastAddress = IPAddress.Parse("70.162.126.181");

            NetServer server = new NetServer(config);
            server.Start();

            Console.WriteLine("Listening...");

            NetIncomingMessage msg;

            while ((msg = server.ReadMessage()) != null)
            {
                switch (msg.MessageType)
                {
                    case NetIncomingMessageType.VerboseDebugMessage:
                    case NetIncomingMessageType.DebugMessage:
                    case NetIncomingMessageType.WarningMessage:
                    case NetIncomingMessageType.ErrorMessage:
                        Console.WriteLine(msg.ReadString());
                        break;
                    default:
                        Console.WriteLine("Unhandled type: " + msg.MessageType);
                        break;
                }
                server.Recycle(msg);
            }
        }
    }
}
