using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV_Parser
{
   static class CsvParser
    {
        private static Dictionary<string, List<string>> parcedString = new Dictionary<string, List<string>>();
        public static char Delimeter { get; set; }
        public static void SaveContent(string filename)
        { 
        }
        public static void LoadContent(string filename)
        {
            using (StreamReader csvReader = new StreamReader(filename))
            {
                string[] csvHeader = csvReader.ReadLine().Split(Delimeter);
                string csvString = string.Empty;
                while (!csvReader.EndOfStream)
                {
                    csvString = csvReader.ReadLine();
                    for (var i = 0; i < csvHeader.Length; i++) 
                    {
                        if (parcedString.ContainsKey(csvHeader[i])) 
                        {
                            parcedString[csvHeader[i]].Add(csvString.Split(Delimeter)[i]);
                        }
                        else
                        {
                            parcedString.Add(csvHeader[i], new List<string>());
                            parcedString[csvHeader[i]].Add(csvString.Split(Delimeter)[i]);
                        }
                    }
                }
            }
        }
    }
}
