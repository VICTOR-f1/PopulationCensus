namespace PopulationCensus.Infrastructure
{
    public class CalculateAge
    {
        public static int CalculateAgeYear(DateTime birthDate, DateTime currentDate)
        {
         
            int age = currentDate.Year - birthDate.Year;
            if (currentDate.Month < birthDate.Month ||
                (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }
    }
}
