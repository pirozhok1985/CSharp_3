using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV_Parser
{
   class CsvParser
    {
        private List<string> parcedString;
        public char Delimeter { get; set; }

        public CsvParser()
        {
            parcedString = new List<string>();
            Delimeter = ';';
        }
        public void SaveContent(string filename)
        {
            using (StreamWriter csvWriter = new StreamWriter(filename)) 
            {
                foreach (var item in parcedString)
                {
                    csvWriter.WriteLine(item);
                }           
            }
        }
        public void LoadContent(string filename)
        {
            using (StreamReader csvReader = new StreamReader(filename))
            {
                string csvString = string.Empty;
                while (!csvReader.EndOfStream)
                {
                    parcedString.Add(csvReader.ReadLine().Replace(Delimeter,'\t'));
                }
            }
        }
    }
}
