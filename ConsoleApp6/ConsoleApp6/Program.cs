using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Program
    {
       public static void Main(string[] args)
        {
            Exspanse exspanse = new Exspanse();
            Console.WriteLine("WELCOME");
            while (true)
            {
                Console.WriteLine("1 to output exspanse");
                Console.WriteLine("2 to create payment");
                Console.WriteLine("3 to get sum");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    exspanse.OutputExspanses();
                }
                if(input == "2")
                {
                    exspanse.CreatePayment();
                }
                if(input == "3")
                {
                    Console.WriteLine(exspanse.GetSum());
                }
                Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                Console.ReadKey();
                Console.Clear();  
            }
        }
    }
}
