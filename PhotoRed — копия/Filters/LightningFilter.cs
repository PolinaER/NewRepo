using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRed
{
    public class LightningFilter : PixelFilter
    {
        //public override ParametrInfo[] GetParametrsInfo()
        //{
        //    return new[]
        //    {
        //        new ParametrInfo()
        //        {
        //            Name="Коэффициент",
        //            MinValue = 0,
        //            MaxValue = 10,
        //            DefaultValue = 1,
        //            Increment = 0.05
        //        }
        //    };
        //}
        public LightningFilter() : base(new LightningParameters()) { }

        public override string ToString()
        {
            return "Осветление/Затемнение";
        }

        public override Pixel ProcessPixel(Pixel pixel, IParameters parametrs)
        {
            return pixel * (parametrs as LightningParameters).Coefficient;
        }
    }
}
