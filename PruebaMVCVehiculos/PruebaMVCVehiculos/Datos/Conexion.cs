using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMVCVehiculos.Datos
{
    public class Conexion
    {
        private string cadenaSql = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSql = builder.GetSection("ConnectionStrings:DefaultConection").Value;
        }

        public string getCadenaSql()
        {
            return cadenaSql;
        }
    }
}
