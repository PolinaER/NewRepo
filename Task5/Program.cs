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

            var numbers = new int[] { 1, 2, 3, 4, 5, 12, 32, 34, 11, 41, 43, 54, 10 };

            var newNumbers = numbers.Where(n => n % 2 != 0).Where(n => n.ToString().Contains("1")).Select(n => 0 - n).ToArray().OrderByDescending(n => n);

            foreach (var n in newNumbers)
                Console.WriteLine(n);

            var a1 = new Record { ClientID = 1, Year = 100, Month = 3, Duration = 10 };
            var a11 = new Record { ClientID = 1, Year = 100, Month = 2, Duration = 10 };
            var a2 = new Record { ClientID = 1, Year = 101, Month = 3, Duration = 10 };
            var b1 = new Record { ClientID = 2, Year = 100, Month = 3, Duration = 1 };
            var b11 = new Record { ClientID = 2, Year = 100, Month = 5, Duration = 1 };
            var c1 = new Record { ClientID = 3, Year = 100, Month = 3, Duration = 13 };
            var cls = new Record[] { a1, a11, a2, b1, b11, c1 };

            PrintClientDurationForYears(cls);

            Console.ReadKey();
        }
        static void PrintClientDurationForYears(Record[] clients)
        {
            clients.OrderBy(cl => cl.ClientID).ThenBy(cl => cl.Year)
                    .Select(n => new Record()
                    {
                        ClientID = n.ClientID,
                        Year = n.Year,
                        Duration = n.Duration + clients.Where(l => l.ClientID == n.ClientID && l.Year == n.Year && l.Month != n.Month)
                        .Select(m => m.Duration).Sum()
                    }).ToArray().Distinct()
                    ;

            foreach (var c in clients)
                Console.WriteLine($"У клиента {c.ClientID} продолжительность занятий {c.Duration} часов за {c.Year} год");
        }
    }
}
