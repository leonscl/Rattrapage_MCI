using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class Plongeur
    {
        public List<Outil> ToolsToWash { get; private set; }
        public void LaveALaMain() { }
        private object LockToolsToWashList = new object();

        private void WashTool(Outil tool)
        {
            Console.WriteLine("Plongeur lave " + tool.Name);
            Thread.Sleep((int)Math.Round(tool.WashingTime * 60000) / 60);
            Console.WriteLine("Plongeur a fini de laver " + tool.Name);
            this.ToolsToWash.Remove(tool);
            ToolsManager.GetInstance().ReleaseTool(tool);

        }

        public Thread StartWorking()
        {
            return new Thread(() =>
            {
                Console.WriteLine("Plongeur se met à travailler");
                while (true)
                {
                    lock (LockToolsToWashList)
                    {
                        List<Outil> tools = new List<Outil>(this.ToolsToWash);
                        if (tools.Count() > 0)
                        {
                            foreach (var item in tools)
                            {
                                this.WashTool(item);
                            }
                        }
                    }
                }
            });
        }

        public void AddToolsToWash(List<Outil> tools)
        {
            lock (LockToolsToWashList)
            {
                foreach (var item in tools)
                {
                    Console.WriteLine(item.Name + " ajouté à la liste d'outil à laver");
                    this.ToolsToWash.Add(item);
                }
            }

        }
    }
}
