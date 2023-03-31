using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRed
{
    public abstract class PixelFilter : ParametrisedFilter
    {
        public PixelFilter(IParameters parameters) : base(parameters) { }

        public override Photo Process(Photo original, IParameters parametrs)
        {
                var newPhoto = new Photo(original.Width, original.Height);

                for (var x = 0; x < original.Width; x++)
                    for (var y = 0; y < original.Height; y++)
                        newPhoto[x, y] = ProcessPixel(original[x, y], parametrs);

                return newPhoto;
        }

        public abstract Pixel ProcessPixel(Pixel pixel, IParameters parametrs);
    }
}
