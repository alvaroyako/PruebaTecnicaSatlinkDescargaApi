using PruebaTecnicaSatlinkDescargaApi.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDescargaDato
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {

            ContextPruebaTecnicaSatLink.ConnectionString = ConfigurationManager.ConnectionStrings["CadenaPostgre"].ConnectionString;

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Descarga()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
