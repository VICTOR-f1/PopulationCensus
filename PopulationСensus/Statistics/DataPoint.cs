using PopulationСensus.Domain.Services;
using System.Runtime.Serialization;

namespace PopulationCensus.Statistics
{
    //DataContract for Serializing Data - required to serve in JSON format
    [DataContract]
    public class DataPoint
    {
        public DataPoint(string label, double y)
        {
            Label = label;
            Y = y;
        }


        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public double? Y = null;
     
    }
}
