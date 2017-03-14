using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumerologicalCalculator
{
    class Program
    {
        private static DateTime startDate;
        private static DateTime endDate;
        static void Main(string[] args)
        {
            Console.WriteLine("Write start date(format - dd.mm.yyyy)");
            var startDateInput = Console.ReadLine();
            CheckInput(startDateInput, true);
            Console.WriteLine("Write end date(format - dd.mm.yyyy)");
            var endDateInput = Console.ReadLine();
            CheckInput(endDateInput, false);
            Calculate();
        }

        private static void Calculate()
        {
            Dictionary<DateTime, int> listOfCalculatedDates = new Dictionary<DateTime, int>();
            for (DateTime date = startDate; date <= endDate; date += TimeSpan.FromDays(1))
            {
                var sum = 0;
                var day = date.Day;
                var month = date.Month;
                var year = date.Year;
                while (day != 0)
                {
                    sum += day % 10;
                    day /= 10;
                }
                while (month != 0)
                {
                    sum += month % 10;
                    month /= 10;
                }
                while (year !=0)
                {
                    sum += year%10;
                    year /= 10;
                }
                if (checkIfSpecial(sum))
                {
                    listOfCalculatedDates.Add(date,sum);
                }
                else
                {
                    while (true)
                    {
                        
                    }
                }
            }
        }

        private static bool checkIfSpecial(int input)
        {
            if (input == 11 || input == 22)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void CheckInput(string input, bool sd)
        {
            DateTime outDate;
            DateTime.TryParse(input, out outDate);
            if (sd)
            {
                Console.WriteLine("Starting date set to: " + outDate.ToLongDateString());
                startDate = outDate;
            }
            else
            {
                Console.WriteLine("Ending date set to: " + outDate.ToLongDateString());
                endDate = outDate;
            }
        }
    }
}
