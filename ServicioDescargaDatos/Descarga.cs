using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace ServicioDescargaDatos
{
    public partial class Descarga : ServiceBase
    {

        public Descarga()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            stLapso.Start();
        }

        protected override void OnStop()
        {
            stLapso.Stop();
        }

        private void stLapso_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            EjecutarPrograma();
        }

        private void EjecutarPrograma()
        {
            try
            {
                string rutaExe = @"E:\PROGRAMACION\PruebaTecnicaSatlinkDescargaApi\PruebaTecnicaSatlinkDescargaApi\bin\Release\net6.0\win-x64\publish\PruebaTecnicaSatlinkDescarga.exe";

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = rutaExe;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar el archivo .exe: " + ex.Message);
            }
        }
    }
}
