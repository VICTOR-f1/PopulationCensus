using PopulationСensus.Domain.Entities;
using System.Reflection.Emit;

namespace PopulationСensus.Data
{
    public static class EFInitialSeed
    {
        public static void Seed(ELibraryContext context)
        {
            if (!context.Residents.Any() && !context.Addresses.Any())
            {
                Address аddress1 = new Address
                {

                    ZipCode = 1,
                    ApartmentNumber = 12,
                    Street = "a",
                    City = "vb",
                    State = "A",
                    Resident = new List<Resident>()
                    {
                        
                        new Resident
                        {
                            FullName = "юлия",
                            DateOfBirth= new DateTime(1981,12,24),

                        }

                    }


                };
                context.Addresses.Add(аddress1);
                context.SaveChanges();
            }
    
        }
    }
}
