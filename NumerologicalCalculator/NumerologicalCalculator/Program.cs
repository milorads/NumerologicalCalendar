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
            for (DateTime date = startDate ; date <= endDate; date += TimeSpan.FromDays(1))
            {
                Calculate(date);
            }
        }

        private static void Calculate(DateTime date)
        {
        }

        private static void CheckInput(string input, bool startDate)
        {
            DateTime outDate;
            DateTime.TryParse(input, out outDate);
            if (startDate)
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
