using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidgren.Harness
{
    public class Client
    {
        public Client()
        {
            var config = new NetPeerConfiguration("SpaceFighter");
            var client = new NetClient(config);
            client.Start();
            client.Connect("70.162.126.181", 5000);

            this.Send(client);
        }

        public void Send(NetClient nc)
        {
            var message = nc.CreateMessage();
            message.Write("This is a test");

            NetSendResult sr = nc.SendMessage(message, NetDeliveryMethod.ReliableOrdered);
            Console.WriteLine(sr.ToString());
            Console.ReadKey();
        }
    }
}
