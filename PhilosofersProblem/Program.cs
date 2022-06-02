using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhilosofersProblem
{
    class Program
    {
        static Fork Fork1 = new ManagedFork();
        static Fork Fork2 = new ManagedFork();
        static Fork Fork3 = new ManagedFork();
        static Fork Fork4 = new ManagedFork();
        static Fork Fork5 = new ManagedFork();

        static async Task Main(string[] args)
        {
            var ph1 = new Thread(Philosofer1);
            var ph2 = new Thread(Philosofer2);
            var ph3 = new Thread(Philosofer3);
            var ph4 = new Thread(Philosofer4);
            var ph5 = new Thread(Philosofer5);

            ph1.Start();
            ph2.Start();
            ph3.Start();
            ph4.Start();
            ph5.Start();
        }

        static void Philosofer1()
        {
            while (!Fork1.Take(1))
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("1: Took 1st fork");

            Thread.Sleep(500);

            while (!Fork2.Take(1))
            {
                Thread.Sleep(1000);
            };
            Console.WriteLine("1: Took 2nd fork");

            Console.WriteLine("1: Eating...");
            Thread.Sleep(2000);
            Console.WriteLine("1: Done!");
            Fork1.Release();
            Fork2.Release();
        }
        static void Philosofer2()
        {
            while (!Fork2.Take(2))
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("2: Took 2nd fork");
            Thread.Sleep(500);
            while (!Fork3.Take(2))
            {
                Thread.Sleep(1000);
            };
            Console.WriteLine("2: Took 3rd fork");

            Console.WriteLine("2: Eating...");
            Thread.Sleep(2000);
            Console.WriteLine("2: Done!");
            Fork2.Release();
            Fork3.Release();
        }
        static void Philosofer3()
        {
            while (!Fork3.Take(3))
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("3: Took 3rd fork");
            Thread.Sleep(500);
            while (!Fork4.Take(3))
            {
                Thread.Sleep(1000);
            };
            Console.WriteLine("3: Took 4th fork");

            Console.WriteLine("3: Eating...");
            Thread.Sleep(2000);
            Console.WriteLine("3: Done!");
            Fork3.Release();
            Fork4.Release();
        }
        static void Philosofer4()
        {
            while (!Fork4.Take(4))
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("4: Took 4th fork");
            Thread.Sleep(500);
            while (!Fork5.Take(4))
            {
                Thread.Sleep(1000);
            };
            Console.WriteLine("4: Took 5th fork");

            Console.WriteLine("4: Eating...");
            Thread.Sleep(2000);
            Console.WriteLine("4: Done!");
            Fork4.Release();
            Fork5.Release();
        }
        static void Philosofer5()
        {
            while (!Fork5.Take(5))
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("5: Took 5th fork");
            Thread.Sleep(500);
            while (!Fork1.Take(5))
            {
                Thread.Sleep(1000);
            };
            Console.WriteLine("5: Took 1st fork");

            Console.WriteLine("5: Eating...");
            Thread.Sleep(2000);
            Console.WriteLine("5: Done!");
            Fork5.Release();
            Fork1.Release();
        }
    }
}
