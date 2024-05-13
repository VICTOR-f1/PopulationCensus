using System.Runtime.Serialization;

namespace PopulationCensus.Domain.Entities
{
	//DataContract for Serializing Data - required to serve in JSON format
	[DataContract]
	public class DataPoint
	{
		public DataPoint(string label, double y)
		{
			this.Label = label;
			this.Y = y;
		}
	     
		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "label")]
		public string Label = "";

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<double> Y = null;
        public static List<DataPoint> CreateListNumberPeoplePassed(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Январь", 0),
                new DataPoint("Февраль", 0),
                new DataPoint("Март", 0),
                new DataPoint("Апрель", 0),
                new DataPoint("Май", 0),
                new DataPoint("Июнь", 0),
                new DataPoint("Июль", 0),
                new DataPoint("Август", 0),
                new DataPoint("Сентабрь", 0),
                new DataPoint("Октябрь", 0),
                new DataPoint("Ноябрь", 0),
                new DataPoint("Декабрь", 0)
            };
            return dataPoints;
        }
    }
}
