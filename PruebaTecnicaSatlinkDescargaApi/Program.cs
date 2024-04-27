using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PruebaTecnicaSatlinkDescargaApi.Data;
using PruebaTecnicaSatlinkDescargaApi.Model;
using static Program;


class Program
{

    static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json");

        var config = configuration.Build();

        ContextPruebaTecnicaSatLink.ConnectionString = config.GetConnectionString("Default");

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