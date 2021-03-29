using System;

namespace CSV_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvFile = @"c:\users\Pirozhok\Downloads\catalog.csv";
            string regularFile = @"c:\users\Pirozhok\Downloads\regular.txt";
            CsvParser myParser = new CsvParser();
            myParser.LoadContent(csvFile);
            myParser.SaveContent(regularFile);
        }
    }
}
