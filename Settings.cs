using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace graphOnlyTutorial
{
    public class Settings
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set;}
        public string? TenantId { get; set;}

        public static Settings LoadSettings()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json",optional:false)
                .AddUserSecrets<Program>()
                .Build();

            return config.GetRequiredSection("Settings").Get<Settings>() ?? throw new Exception("could not load appsettings");
        }
    }
}
