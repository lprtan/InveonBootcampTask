using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IveonBootcamp.Asynchronous.Services
{
    public class ServiceAstroidInfo
    {
        public static void GetAstoridDataSync()
        {
            try
            {
                var nasaResponse = FetchNasaData();
                if (nasaResponse?.NearEarthObjects != null)
                {
                    foreach (var dateEntry in nasaResponse.NearEarthObjects)
                    {
                        Console.WriteLine($"Date: {dateEntry.Key}");
                        foreach (var obj in dateEntry.Value)
                        {
                            Console.WriteLine($"  ID: {obj.Id}, Name: {obj.Name}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static NasaResponse FetchNasaData()
        {
            using var httpClient = new HttpClient();
            var response = httpClient.GetAsync(Constants.BaseUrl).Result;

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Request failed with status code: {response.StatusCode}");
            var jsonContent = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<NasaResponse>(jsonContent);
        }
    }
}
