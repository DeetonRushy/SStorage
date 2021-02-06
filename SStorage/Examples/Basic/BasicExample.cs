using System;
using System.Diagnostics;
using Storage;
using Storage.Utils;

// File is not compiled.

namespace MyApp
{
    class Program
    {
        public static IStorage worker = HelperFactory.SStorage();

        static void Main(string[] args)
        {
            WriteSome();
            ReadSome();
            SaveAll();
            LoadAll();

            Console.ReadKey();
        }

        static void WriteSome()
        {
            Stopwatch watcher = new Stopwatch();
            watcher.Start();

            worker.Write("ABool", true);
            worker.Write("AString", "Hello World!");
            worker.Write("AByte", 0x1);

            watcher.Stop();
            Console.WriteLine($"It took {watcher.ElapsedMilliseconds}ms to write a bool, string and byte!");
        }

        static void ReadSome()
        {
            Stopwatch watcher = new Stopwatch();
            Console.WriteLine("Reading written data...");
            watcher.Start();

            bool a;
            long b;
            string c;
            sbyte d;

            a = worker.ReadBool("ABool");
            c = worker.ReadString("AString");
            d = worker.ReadSByte("AByte");

            watcher.Stop();
            Console.WriteLine($"Took {watcher.ElapsedMilliseconds}ms to read the 3 values - {a}, {c}, {d}");
        }

        static void SaveAll()
        {
            Stopwatch waiter = new Stopwatch();
            waiter.Start();

            worker.Save("our-saved-data.json");

            waiter.Stop();

            Console.WriteLine($"It took {waiter.ElapsedMilliseconds}ms to save the data!");
        }

        static void LoadAll()
        {
            Stopwatch waiter = new Stopwatch();
            waiter.Start();

            worker.Save("our-saved-data.json");

            waiter.Stop();

            Console.WriteLine($"It took {waiter.ElapsedMilliseconds}ms to load the data!");
        }
    }
}
