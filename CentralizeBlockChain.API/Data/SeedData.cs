using CentralizeBlockChain.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentralizeBlockChain.API.Data
{
    public static class DbSeeder
    {
        public static IHost SeedDb(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    context.SeedRecords().Wait();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return webHost;
        }




        public static async Task SeedRecords(this ApplicationDbContext context)
        {

            if (await context.Records.AnyAsync())
            {
                return;
            }
            var records = new List<Record>();

            var record = new Record();
            record.pervious_hash = "00000000000000000000000000";
            record.Timestamp = DateTime.Now;
            record.proof = 1;


            records.Add(record);


            await context.Records.AddRangeAsync(records);
            await context.SaveChangesAsync();


        }

    }

}
