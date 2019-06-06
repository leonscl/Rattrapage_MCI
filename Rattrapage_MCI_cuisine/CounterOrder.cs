using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class CounterOrder
    {
        //propriétés
        private Thread counterOrderThread;
        Int32 port = 13000;
        IPAddress localAddress = IPAddress.Parse("127.0.0.1");

        //Constructeur
        public CounterOrder()
        {
            CounterOrderThread = new Thread(CounterorderWorkThread);
            CounterOrderThread.Start();
        }

        //thread du TcpListener pour écouter la salle et récupérer les commandes
        public void CounterorderWorkThread()
        {
            ReceiveOrder();
        }

        //enlever static si le constructeur est utilisé
        public static void ReceiveOrder()
        {
            TcpListener server = null;

            try
            {
                //a envlever si le constructeur est utilisé
                Int32 Port = 13000;
                IPAddress LocalAddress = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(LocalAddress, Port);
                // Start listening for client requests.
                server.Start();

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("\n Connected!");

                    //https://stackoverflow.com/questions/2029022/get-length-of-data-sent-over-network-to-tcplistener-networkstream-vb-net

                    MemoryStream stream1 = new MemoryStream();

                    using (NetworkStream ns = client.GetStream())
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        stream1 = (MemoryStream)bf.Deserialize(ns);
                    }

                    //Juste afficher mon stream jSON
                    stream1.Position = 0;
                    StreamReader sr = new StreamReader(stream1);
                    Console.Write("JSON form of Person object: ");
                    Console.WriteLine(sr.ReadToEnd());

                    //créer mon objet à partir de mon Json et afficher id ce la commande pour vérifier
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Order));
                    stream1.Position = 0;
                    Order newOrder = (Order)ser.ReadObject(stream1);
                    Console.Write("id de la commande" + newOrder.IdOrder);


                    // Shutdown and end connection
                    client.Close();

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }

        //getter et setter
        public int Port { get => port; set => port = value; }
        public Thread CounterOrderThread { get => counterOrderThread; set => counterOrderThread = value; }
        public IPAddress LocalAddress { get => localAddress; set => localAddress = value; }
    }
}
