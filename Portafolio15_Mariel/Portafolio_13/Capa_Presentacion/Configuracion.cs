using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Presentacion
{
    class Configuracion
    {
        public static string getConnectionString
        {
            get
            {
            return Properties.Settings.Default.ConnectionString;
            }
        }
    }
}
