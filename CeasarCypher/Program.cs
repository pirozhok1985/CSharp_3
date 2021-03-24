using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            string regularStr = "Lets buy some pizza! It is so Yammy!";
            Console.WriteLine($"This is regular string: {regularStr}");

            string encryptStr = Cypher.Encrypt(regularStr);
            Console.WriteLine($"This is encrypted string: {encryptStr}");


            string decryptStr = Cypher.Decrypt(encryptStr);
            Console.WriteLine($"This is decrypted string: {decryptStr}");

            Console.ReadLine();
        }
    }
}
