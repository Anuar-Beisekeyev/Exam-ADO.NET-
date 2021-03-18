using ExamADO.NET.Services;
using System;
using System.Data.SqlClient;
using ExamADO.NET.Data;

namespace ExamADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {       

            InitConfiguration();
            
        }
        private static void InitConfiguration()
        {
            ConfigurationService.Init();
        }
    }
}
