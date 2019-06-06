using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class SocketCom
    {
        public Socket Cnx { get; set; }

        /// <summary>
        /// Create a connection 
        /// </summary>
        public SocketCom(string server, int port)
        {
            this.Cnx = this.ConnectSocket(server, port);
            Console.WriteLine(this.Cnx);
        }

        /// <summary>
        /// Initiate socket connection
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <returns>A socket connection</returns>
        private Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(server), port);
            s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ipe);
            return s;
        }

        /// <summary>
        /// Send an object in the socket
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        /// 
       /* public bool Send(Object obj)
        {
            string msg = Serialization.SerializeAnObject(obj);
            msg += "<EOF>";

            // Get the socket connection
            using (this.Cnx)
            {
                if (this.Cnx == null)
                    return false;

                byte[] bytes = Encoding.ASCII.GetBytes(msg);

                // Send request to the server.
                this.Cnx.Send(bytes);
            }
            return true;
        } */
    }
}
}
