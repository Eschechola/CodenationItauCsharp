using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsoleApp1.Utilities
{
    public class SettingsInjection
    {
        //dependencia do arquivo de configuração
        public IConfigurationRoot Configuration { get; set; }

        public SettingsInjection()
        {
            InjectSettings();
        }

        public IConfigurationRoot GetSettings()
        {
            return Configuration;
        }

        private void InjectSettings()
        {
            try
            {
                //injeção de dependencia do arquivo appsettings.json
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                Configuration = builder.Build();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
