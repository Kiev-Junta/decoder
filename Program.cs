using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Decoder
{
    class Program
    {
        static void Main(string[] args)
        {
           var reader = new StreamReader("text.txt",Encoding.GetEncoding(1251));

            string srcText = reader.ReadToEnd();
            reader.Close();

            string proposalPattern = @"(^(\w+ая)|(\w+ее)|(\w+ое)|(\w+ый)|(\w+ой)|\n$)";
            var proposalRegex = new Regex(proposalPattern);
            var decodedText = new StringBuilder();


            Console.WriteLine("Please wait... Text is analysing....\n");

            foreach(Match m in Regex.Matches(srcText,@"(\w+)|[.,!-?()]"))
            {
                if(proposalRegex.IsMatch(m.ToString()))
                {
                    decodedText.Append("ГАВ").Append(" ");
                }
                else
                {
                    decodedText.Append(m).Append(" ");
                }
                
            }

           
            var writer = new StreamWriter("text.txt");
            writer.Write(decodedText);
            writer.Close();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDone!");
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ReadKey();
        }
    }
}
