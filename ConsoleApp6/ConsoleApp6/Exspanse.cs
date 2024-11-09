using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp6
{
    public class Exspanse
    {
        private ExspanseCategory _exspanseCategory;
        private string _paymentsJsonFilePath = "payments.json";

        public List<Payment> payments = new List<Payment>();

        public Exspanse()
        {
            _exspanseCategory = new ExspanseCategory();
            LoadData();
        }

        public void OutputExspanses()
        {
            foreach (var payment in payments)
                Console.WriteLine(payment.ToString());
        }

        public int GetSum()
        {
            int sum = 0;
            foreach (var payment in payments)
                sum += payment.Amount;
            return sum;
        }

        public void OutputAllCategory()
        {
            for (int i = 0; i < _exspanseCategory.Category.Count; i++)
            {
                Console.WriteLine($"{i}. {_exspanseCategory.Category[i]}");
            }
        }

        public void CreatePayment()
        {
            while(true)
            {
                Console.WriteLine("INPUT YOUR AMOUNT");
                string amount = Console.ReadLine();
                Payment currentPayment = new Payment();
                if (Int32.TryParse(amount, out int result))
                {
                    currentPayment.Amount = result;
                }
                else
                {
                    Console.WriteLine("WRONG AMOUNT");
                    continue;
                }
                Console.WriteLine("INPUT YOUR CATEGORY FROM -");
                OutputAllCategory();
                string currentCategory = Console.ReadLine();

                if (Int32.TryParse(currentCategory, out int resultCategory))
                {
                    if(resultCategory < _exspanseCategory.Category.Count)
                    {
                        currentPayment.CurrentCategory = _exspanseCategory.Category[resultCategory];
                    }
                }
                else
                {
                    Console.WriteLine("WRONG CATEGORY");
                    continue;
                }
                payments.Add(currentPayment);
                SaveData();
                break;
            }
        }

        public void SaveData()
        {
            string jsonPayments = JsonConvert.SerializeObject(payments, Formatting.Indented);
            File.WriteAllText(_paymentsJsonFilePath, jsonPayments);
        }

        public void LoadData()
        {
            if(File.Exists(_paymentsJsonFilePath))
            {
                string jsonPayments = File.ReadAllText(_paymentsJsonFilePath);
                payments = JsonConvert.DeserializeObject<List<Payment>>(jsonPayments) ?? new List<Payment>();
            }
        }
    }
}