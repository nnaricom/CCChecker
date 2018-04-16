using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CCChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string json = File.ReadAllText(@"C:\cards.json");


            List<CreditCard> CardList = JsonConvert.DeserializeObject<List<CreditCard>>(json);
            Console.WriteLine(CardList[0].CardNumber);

            foreach (CreditCard cc in CardList)
            {
                if (cc.Validate())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("CC number " + cc.CardNumber + " is valid.   | "  + cc.IssuingNetwork);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("CC number " + cc.CardNumber + " is INVALID. | " + cc.IssuingNetwork);
                }
            }

            Console.ResetColor();
        }
    }
}
