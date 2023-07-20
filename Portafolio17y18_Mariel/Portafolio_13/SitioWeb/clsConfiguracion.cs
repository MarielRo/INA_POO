using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration; //Para utilizar Configuration Manager

namespace SitioWeb
{
    public static class clsConfiguracion
    {
        public static string getConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }
        }
    }
}