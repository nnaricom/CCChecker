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
            //Get json from path
            string json = File.ReadAllText(@"C:\cards.json");

            //Deserialize to array of CreditCard
            RootObject[] root = JsonConvert.DeserializeObject<RootObject[]>(json);
            //Prepare a list
            List<CreditCard> CardList = new List<CreditCard>();

            //Loop array members to our newly created list
            for(int i = 0; i < root.Length; i++)
            {
                CardList.Add(root[i].CreditCard);
            }
            
            //Validate each card with Luhn's algorithm
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
