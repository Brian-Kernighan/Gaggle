using System.Collections.Generic;

namespace GaggleService.Gaggle.Network.Builders
{
    public class ParametersBuilder
    {
        private readonly List<object> _args;

        public ParametersBuilder()
        {
            _args = new List<object>();
        }

        public void Append(object value)
        {
            _args.Add(value);
        }

        public object[] Build()
        {
            return _args.ToArray();
        }
    }
}
