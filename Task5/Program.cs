using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = new int[] { 1, 2, 3, -4, 5, -12, 32, 34, -11, 41, 43, 54, 10, -2,-13 };

            var newNumbers = numbers.Where(n => n % 2 != 0 && n<0).Where(n => n.ToString().Contains("1")).ToArray().OrderByDescending(n => n);

            foreach (var n in newNumbers)
                Console.WriteLine(n);

            var records = new List<Record>            {                 
                new Record() {ClientID = 1, Year = 2023, Month = 1, Duration = 30},
                new Record() {ClientID = 1, Year = 2023, Month = 3, Duration = 32},
                new Record() {ClientID = 1, Year = 2023, Month = 4, Duration = 12},
                new Record() {ClientID = 1, Year = 2023, Month = 5, Duration = 16},
                new Record() {ClientID = 2, Year = 2023, Month = 1, Duration = 12},
                new Record() {ClientID = 2, Year = 2023, Month = 2, Duration = 18},
                new Record() {ClientID = 2, Year = 2023, Month = 3, Duration = 32},
                new Record() {ClientID = 3, Year = 2023, Month = 1, Duration = 56},
                new Record() {ClientID = 3, Year = 2023, Month = 2, Duration = 48},
                new Record() {ClientID = 1, Year = 2022, Month = 4, Duration = 12},
                new Record() {ClientID = 1, Year = 2022, Month = 5, Duration = 16},
                new Record() {ClientID = 2, Year = 2022, Month = 1, Duration = 12},
                new Record() {ClientID = 2, Year = 2022, Month = 2, Duration = 18},
                new Record() {ClientID = 2, Year = 2022, Month = 3, Duration = 32},
                new Record() {ClientID = 3, Year = 2022, Month = 1, Duration = 56},
            };

            PrintClientDurationForYears(records);


            Console.ReadKey();
        }
        static void PrintClientDurationForYears(List<Record> records)
        {
            var nrn = records
                    .Select(n => new Record()
                    {
                        ClientID = n.ClientID,
                        Year = n.Year,
                        Duration = n.Duration + records.Where(l => l.ClientID == n.ClientID && l.Year == n.Year && l.Month != n.Month).Distinct().Select(m => m.Duration).Sum()
                    }).Distinct().OrderBy(cl => cl.ClientID).ThenBy(cl => cl.Year)
;

            foreach (var c in nrn)
                Console.WriteLine($"У клиента {c.ClientID} продолжительность занятий {c.Duration} часов за {c.Year} год");
        }
    }
}
