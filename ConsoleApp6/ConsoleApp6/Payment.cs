using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public class Payment
    {
        private DateTime _date;
        public string CurrentCategory { get; set; }
        public int Amount { get; set; }

        public Payment()
        {
            _date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{CurrentCategory} | {Amount} | {_date.Day} in {_date.Month}";
        }
    }
}
