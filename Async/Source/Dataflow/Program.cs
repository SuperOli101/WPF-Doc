using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Dataflow
{
    class Program
    {
        static void Main()
        {
            int capacity = 15;
            var items = new BufferBlock<WorkingObject>(new DataflowBlockOptions { BoundedCapacity = capacity });

            // Erzeuger
            Task.Run(
                async delegate
                    {
                        int ctr = 0;
                        while (true)
                        {
                            WorkingObject item = Produce(ctr++);
                            await items.SendAsync(item);
                            PrintBuffer(items.Count, capacity);
                        }
                    }
            );

            // Verbraucher
            for (int i = 0; i < 5; i++)
            {
                Task.Run(
                    async delegate
                    {
                        while (true)
                        {
                            WorkingObject item = await items.ReceiveAsync();
                            Consume(item);
                            PrintBuffer(items.Count, capacity);
                        }
                    }
                );
            }
            Console.Read();
        }

        private static void PrintBuffer(int p, int capacity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("|");
            for (int i = 0; i < capacity; i++)
            {
                if (i < p)
                {
                    sb.Append("X");
                }
                else
                {
                    sb.Append("O");
                }
            }
            sb.Append("|");
            Console.WriteLine(sb.ToString());
        }

        private static WorkingObject Produce(int id)
        {
            var item = new WorkingObject(id);
            return item;
        }

        private static void Consume(WorkingObject item)
        {
            item.DoWork();
        }
    }
}
