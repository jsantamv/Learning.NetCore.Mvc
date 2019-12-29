using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Learning.FrontEnd.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Learning.FrontEnd
{
    public class Program
    {
        /// <summary>
        /// antes de que se crea la aplicacion garantizamos que
        /// los datos ya han sido creados. 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                //utilizamos el patron de diseno DI (Dependecy Injection)
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<EscuelaContext>();
                    //garantia de creacion de datos. 
                    //validacion previa antes de iniciarlizar el programa.
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
