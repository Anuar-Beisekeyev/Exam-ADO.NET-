using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace ExamADO.NET.Services
{
    public static class ConfigurationService
    {
        public static IConfiguration Configuration { get; private set; }

        public static void Init()
        {

            DbProviderFactories.RegisterFactory("ConnectedProvider", SqlClientFactory.Instance);
            
            if (Configuration == null)
            {
                var configuratonBuilder = new ConfigurationBuilder();
                Configuration = configuratonBuilder.AddJsonFile("appSetting.json").Build();
            }
        }
    }
}
