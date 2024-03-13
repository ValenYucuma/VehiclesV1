using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public static class DefaultVehicles
    {
        public static async Task SeedAsync()
        {
            //Seed Default Vehicles
            var defaultUser = new Vehicles
            {
                ID = 001,
                Km = 2000,
                Brand = "Renault",
                LocationId = 1,
                Model = 2023,
                Type = "Sandero"
                

            };

        }
    }
}
