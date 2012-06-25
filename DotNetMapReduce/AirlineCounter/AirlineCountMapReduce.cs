using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSDN.Hadoop.MapReduceBase;

namespace AirlineCounter
{
    public class AirlineCountMapper : MapperBaseText<Int32>
    {
        public override IEnumerable<Tuple<string, int>> Map(string value)
        {
            var flightData = value.Split(',');
            var destinationAirport = flightData[4];
            var arrivalDelay = Int32.Parse(flightData[0]); 
            yield return new Tuple<string, int>(destinationAirport,arrivalDelay );
        }
    }

    public class AirlineCountReducer : ReducerBase<Int32, String>
    {
        public override IEnumerable<Tuple<string, string>> Reduce(string key, IEnumerable<Int32> values)
        {
            yield return new Tuple<string, string>(key, values.Count().ToString());
        }
    }
}
