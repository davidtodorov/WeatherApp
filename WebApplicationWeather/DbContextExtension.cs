using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Weather.Data;
using Weather.Data.Models;

namespace WebApplicationWeather
{
    public static class DbContextExtension
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<WeatherDbContext>();
                var citiess = context.Cities;
                if (!context.Cities.Any())
                {
                    var citiesJson = File.ReadAllText("../city.list.min.json");

                   var cities = JsonConvert.DeserializeObject<List<City>>(citiesJson);
                   var bulgariaCities = cities.Where(c => c.Country == "BG").ToList();
                   context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Cities ON");

                    context.Cities.AddRange(cities);
                    context.SaveChanges();
                }
            }
        }
    }
}
