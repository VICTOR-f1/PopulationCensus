using System.Runtime.Serialization;

namespace PopulationCensus.Domain.Entities
{
    [DataContract]
    public class DataPoint
    {
        public DataPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public double? X = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public double? Y = null;
    }
}
