using System;
using System.Threading;

namespace CSV_Parser
{
    class Program
    {
        private static AutoResetEvent wait = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            string csvFile = "catalog.csv";
            string regularFile = "regular.txt";
            CsvParser myParser = new CsvParser();

            ParameterizedThreadStart OnLoadContent = new ParameterizedThreadStart(myParser.LoadContent);
            ParameterizedThreadStart OnSaveContent = new ParameterizedThreadStart(myParser.SaveContent);
            Thread load = new Thread(OnLoadContent);
            load.Name = "LoadThread";
            Thread save = new Thread(OnSaveContent);
            save.Name = "SaveThread";
            load.Start(csvFile);
            Console.WriteLine($"Loading csv file has been invoked on thread number {load.ManagedThreadId}");
            wait.WaitOne();
            save.Start(regularFile);
            Console.WriteLine($"Saving regular file has been invoked on thread number {save.ManagedThreadId}");
        }
    }
}
