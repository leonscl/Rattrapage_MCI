using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class CounterDishes
    {
        //propriétés
        private Thread socketDishesThread;
        private List<string> dishes;

        Int32 port = 13001;
        string serverIp = "127.0.0.1";

        //Constructeur
        public CounterDishes()
        {
            SocketDishesThread = new Thread(SocketDishesWorkThread);
            SocketDishesThread.Start();
        }

        //thread du headWaiter
        public void SocketDishesWorkThread()
        {
            while (true)
            {

                ///// Cette partie est à adapter à la cuisine


                
                /*
                List<Order> orders = SocketServer.Instance.Orders;

                if (orders == null)
                {
                    Thread.Sleep(1000);
                }
                else if (orders.Count > 0)
                {
                    Order order = orders.First();

                    Dishes = new List<string>();

                    Thread.Sleep(1000);
                    //Thread.Sleep(15000);
                    Dishes.Add(order.IdOrder.ToString());
                    Dishes.Add("entrees");
                    Console.Write("\n Contenu dishes ----" + Dishes[1] + " ------ \n");
                    SendDishs(Dishes);

                    Thread.Sleep(1000);
                    //Thread.Sleep(35000);
                    Dishes.Clear();
                    Dishes.Add(order.IdOrder.ToString());
                    Dishes.Add("plats");
                    Console.Write("\n Contenu dishes ----" + Dishes[1] + " ------ \n");
                    SendDishs(Dishes);

                    Thread.Sleep(1000);
                    //Thread.Sleep(15000);
                    Dishes.Clear();
                    Dishes.Add(order.IdOrder.ToString());
                    Dishes.Add("desserts");
                    Console.Write("\n Contenu dishes ----" + Dishes[1] + " ------ \n");
                    SendDishs(Dishes);


                    orders.Remove(order);
                }
                */

                //////
            }

        }


        //Méthode pour envoier les plats prets via un TcpClient
        public void SendDishs(List<string> dishes)
        {
            try
            {
                //Instanciation du TcpClient
                TcpClient client = new TcpClient(ServerIp, Port);

                //Envois de la commande au server TcpListener via NetworkStream en utilisant BinaryFormatter
                using (NetworkStream ns = client.GetStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ns, dishes);
                }
                Console.Write("\n dish envoyé ----" + Dishes[1] + " --- \n");
                //on stope le TcpClient
                client.Close();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

        }

        //getter et setter
        public int Port { get => port; set => port = value; }
        public string ServerIp { get => serverIp; set => serverIp = value; }
        public Thread SocketDishesThread { get => socketDishesThread; set => socketDishesThread = value; }
        public List<string> Dishes { get => dishes; set => dishes = value; }

    }
}
