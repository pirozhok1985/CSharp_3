using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CeasarCypher
{
    static public class Cypher
    {
        public static List<char> Alphabet { get; } = new List<char>
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        private static readonly int _shift = 2;
        private static char _cypherLetter;
        public static string Encrypt(string somestring)
        {
            string cypherString = string.Empty;
            char letter;

            foreach (var c in somestring)
            {
                letter = (char.IsUpper(c)) ? char.ToLower(c) : c;
                if (Regex.IsMatch(letter.ToString(), @"\W|\s"))
                {
                    cypherString += letter;
                }
                else
                {
                    if (Alphabet.IndexOf(letter) >= Alphabet.Count - 2)
                    {
                        _cypherLetter = Alphabet[_shift - (Alphabet.Count - Alphabet.IndexOf(letter))];
                        cypherString += (char.IsUpper(c) == false) ? _cypherLetter : char.ToUpper(_cypherLetter);
                    }
                    else
                    {
                        _cypherLetter = Alphabet[Alphabet.IndexOf(letter) + _shift];
                        cypherString += (char.IsUpper(c) == false) ? _cypherLetter : char.ToUpper(_cypherLetter);
                    }
                }
            }
            return cypherString;
        }
        public static string Decrypt(string somestring)
        {
            string unCypherString = string.Empty;
            char letter;
            foreach (var c in somestring)
            {
                letter = (char.IsUpper(c)) ? char.ToLower(c) : c;
                if (Regex.IsMatch(letter.ToString(), @"\W|\s"))
                {
                    unCypherString += letter;
                }
                else
                {
                    if (Alphabet.IndexOf(letter) <= 1)
                    {
                        _cypherLetter = Alphabet[Alphabet.Count + Alphabet.IndexOf(letter) - _shift];
                        unCypherString += (char.IsUpper(c) == false) ? _cypherLetter : char.ToUpper(_cypherLetter);
                    }
                    else
                    {
                        _cypherLetter = Alphabet[Alphabet.IndexOf(letter) - _shift];
                        unCypherString += (char.IsUpper(c) == false) ? _cypherLetter : char.ToUpper(_cypherLetter);
                    }
                }
            }
            return unCypherString;
        }
    }
}