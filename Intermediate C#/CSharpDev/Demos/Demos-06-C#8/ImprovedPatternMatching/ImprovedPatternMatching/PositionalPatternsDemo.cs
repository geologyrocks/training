using System;
using System.Collections.Generic;
using System.Text;

namespace ImprovedPatternMatching
{
    class PositionalPatternsDemo
    {
        private class TelNum
        {
            public string Country { get; set; }
            public string Number { get; set; }

            public void Deconstruct(out string country, out string number)
            {
                country = this.Country;
                number = this.Number;
            }
        }

        public static void DoDemo()
        {
            Console.WriteLine("\nPositionalPatternsDemo");
            Console.WriteLine("------------------------------------------------------");

            ProcessTelNum1(new TelNum { Country = "UK", Number = "01234 567890" });
            ProcessTelNum1(new TelNum { Country = "NO", Number = "12345678" });
            ProcessTelNum1(new TelNum { Country = "SG", Number = "1234 5678" });
            ProcessTelNum1(new TelNum { Country = "SA", Number = "11 222 3333" });

            ProcessTelNum2(new TelNum { Country = "UK", Number = "01234 567890" });
            ProcessTelNum2(new TelNum { Country = "NO", Number = "12345678" });
            ProcessTelNum2(new TelNum { Country = "SG", Number = "1234 5678" });
            ProcessTelNum2(new TelNum { Country = "SA", Number = "11 222 3333" });

            ProcessTelNum3(new TelNum { Country = "UK", Number = "01234 567890" });
            ProcessTelNum3(new TelNum { Country = "NO", Number = "12345678" });
            ProcessTelNum3(new TelNum { Country = "SG", Number = "1234 5678" });
            ProcessTelNum3(new TelNum { Country = "SA", Number = "11 222 3333" });
        }

        private static void ProcessTelNum1(TelNum telNum)
        {
            string fullNum;
            switch (telNum)
            {
                case TelNum("UK", var num):
                    fullNum = $"+44 {num}";
                    break;
                case TelNum("NO", var num):
                    fullNum = $"+47 {num}";
                    break;
                case TelNum("SG", var num):
                    fullNum = $"+65 {num}";
                    break;
                default:
                    fullNum = $"[{telNum.Country}] {telNum.Number}";
                    break;
            }
            Console.WriteLine($"Full telephone number: {fullNum}");
        }

        private static void ProcessTelNum2(TelNum telNum)
        {
            string fullNum = telNum switch
            {
                TelNum("UK", var num) => $"+44 {num}",
                TelNum("NO", var num) => $"+47 {num}",
                TelNum("SG", var num) => $"+65 {num}",
                _ => $"[{telNum.Country}] {telNum.Number}"
            };
            Console.WriteLine($"Full telephone number: {fullNum}");
        }

        private static void ProcessTelNum3(TelNum telNum)
        {
            string internationalDiallingCode = telNum switch
            {
                TelNum("UK", _) => "+44",
                TelNum("NO", _) => "+47",
                TelNum("SG", _) => "+65",
                _ => $"[{telNum.Country}]"
            };
            Console.WriteLine($"International dialling code: {internationalDiallingCode}");
        }
    }
}
