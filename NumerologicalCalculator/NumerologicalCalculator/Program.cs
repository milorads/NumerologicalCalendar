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
        private static Dictionary<DateTime, int> listOfCalculatedDates;

        static void Main(string[] args)
        {
            Console.WriteLine("Write start date(format - dd.mm.yyyy)");
            var startDateInput = Console.ReadLine();
            CheckInput(startDateInput, true);
            Console.WriteLine("Write end date(format - dd.mm.yyyy)");
            var endDateInput = Console.ReadLine();
            CheckInput(endDateInput, false);
            Calculate();
            Console.WriteLine("Please write desired value 1-9 or 11 or 22 (!0 to list all the values)");
            var desiredNumberInput = Console.ReadLine();
            var desiredNumber = int.Parse(desiredNumberInput);
            if (desiredNumber > 0 && desiredNumber <= 9 || desiredNumber == 11 || desiredNumber == 22)
            {
                foreach (var dateIntPair in listOfCalculatedDates)
                {
                    if (dateIntPair.Value ==desiredNumber)
                    {
                        Console.WriteLine(dateIntPair.Key.ToLongDateString());
                    }
                }
            }
            else if (desiredNumber == 0)
            {
                foreach (var dateIntPair in listOfCalculatedDates)
                {
                        Console.Write(dateIntPair.Key.ToLongDateString());
                    Console.WriteLine(" - This day has value: "+ dateIntPair.Value.ToString());
                }
            }
            else
            {
                Console.WriteLine("Wrong number input");
            }
            Console.Read();
        }

        private static void Calculate()
        {
            listOfCalculatedDates = new Dictionary<DateTime, int>();
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
                var sumOfSum = 0;
                if (checkIfSpecial(sum))
                {
                    listOfCalculatedDates.Add(date,sum);
                }
                else
                {
                    while (sum != 0)
                    {
                        if (checkIfSpecial(sum))
                        {
                            listOfCalculatedDates.Add(date, sum);
                        }
                        else
                        {
                            sumOfSum += sum % 10;
                            sum /= 10;
                        }
                    }
                    if (sumOfSum/10 >0)
                    {
                        sumOfSum = sumOfSum / 10 + sumOfSum % 10;
                        listOfCalculatedDates.Add(date,sumOfSum);
                    }
                    else
                    {
                        listOfCalculatedDates.Add(date,sumOfSum);

                    }
                }
            }
        }

        public static double sumDigits(double n)
        {
            return (1 + ((n - 1) % 9));
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
