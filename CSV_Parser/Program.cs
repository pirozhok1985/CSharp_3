using System;

namespace CSV_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvFile = @"c:\users\Pirozhok\Downloads\catalog.csv";
            CsvParser.Delimeter = ';';
            CsvParser.LoadContent(csvFile);
        }
    }
}
