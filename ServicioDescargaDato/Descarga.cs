using Newtonsoft.Json;
using PruebaTecnicaSatlinkDescargaApi.Data;
using PruebaTecnicaSatlinkDescargaApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDescargaDato
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
            EjecutarDescarga();
        }

        private static async Task EjecutarDescarga()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();

                        List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonContent);

                        Insert(users);

                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public static void Insert(List<User> users)
        {
            foreach (var user in users)
            {
                UsersRepository.Save(user);
            }

            Console.WriteLine("Usuarios insertados con exito");
        }
    }
}
