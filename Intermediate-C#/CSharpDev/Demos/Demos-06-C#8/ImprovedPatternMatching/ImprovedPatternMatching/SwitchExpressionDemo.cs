using System;
using System.Collections.Generic;
using System.Text;

namespace ImprovedPatternMatching
{
    public class SwitchExpressionDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nSwitchExpressionDemo");
            Console.WriteLine("------------------------------------------------------");

            UseSwitchStatement();
            UseSwitchExpression();
        }

        private static void UseSwitchStatement()
        {
            int month = 12;
            string monthName;
            switch (month)
            {
                case 1:
                    monthName = "January";
                    break;
                case 2:
                    monthName = "February";
                    break;
                case 3:
                    monthName = "March";
                    break;
                case 4:
                    monthName = "April";
                    break;
                case 5:
                    monthName = "May";
                    break;
                case 6:
                    monthName = "June";
                    break;
                case 7:
                    monthName = "July";
                    break;
                case 8:
                    monthName = "August";
                    break;
                case 9:
                    monthName = "September";
                    break;
                case 10:
                    monthName = "October";
                    break;
                case 11:
                    monthName = "November";
                    break;
                case 12:
                    monthName = "December";
                    break;
                default:
                    monthName = "Unknown";
                    break;
            }
            Console.WriteLine($"Month {month} is {monthName}");
        }

        static private void UseSwitchExpression()
        {
            int month = 12;
            string monthName = month switch
            {
                1 => "January",
                2 => "February",
                3 => "March",
                4 => "April",
                5 => "May",
                6 => "June",
                7 => "July",
                8 => "August",
                9 => "September",
                10 => "October",
                11 => "November",
                12 => "December",
                _ => "Unknown"
            };
            Console.WriteLine($"Month {month} is {monthName}");
        }
    }
}
