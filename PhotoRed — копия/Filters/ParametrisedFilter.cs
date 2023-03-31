using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRed
{
    public abstract class ParametrisedFilter : IFilter
    {
        IParameters parameters;

        public ParametrisedFilter(IParameters parameters) => this.parameters = parameters;

        public ParametrInfo[] GetParametrsInfo() => parameters.GetDiscription();

        public Photo Process(Photo original, double[] values)
        {
            parameters.SetValues(values);
            return Process(original, parameters);
        }

        public abstract Photo Process(Photo original, IParameters parameters);
    }
}
