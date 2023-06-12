using PhotoRed;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleHandler = new SimpleParametersHandler<LightningParameters>();
            var staticHandler = new StaticParametersHandler<LightningParameters>();

            TestLighteningParameters(v => simpleHandler.CreateParameters(v), 500000);
            TestLighteningParameters(v => staticHandler.CreateParameters(v), 500000);
            TestLighteningParameters(v => new LightningParameters() { Coefficient = v[0] }, 500000);

            Console.ReadKey();
        }

        static void TestLighteningParameters(Func<double[], LightningParameters> method, int n)
        {
            var values = new double[] { 1 };

            method(values);

            var watch = new Stopwatch();
            watch.Start();

            for (var i = 0; i < n; i++)
                method(values);

            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds * 1000.0 / n);
        }
    }
}
