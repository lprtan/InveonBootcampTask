//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IveonBootcamp.Asynchronous.Services
{
    public class ServiceAstroidInfoAsync
    {
        public static async Task<ServiceResult<NasaResponse>> GetAstoridDataAsync()
        {
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("\nDaily astronomy image\n");
                var dataAsteroid = httpClient.GetAsync(Constants.BaseUrl);

                await Task.Delay(3000); //İkinci isteği göndermeden önce 3 saniye beklemesini sağlar

                var dailyAstronomyImage = httpClient.GetAsync(Constants.ApodBaseUrl);

                // Paralel olarak birkaç API çağrısı yapmak ve hepsi tamamlandığında işleme devam etmek için kullanılır.
                var responses = await Task.WhenAll(dataAsteroid, dailyAstronomyImage);
                var responseDataAsteroid = responses[0];
                var responseImage = responses[1];

                // En hızlı çalışan API kullanmak için 
                var firstFinishedTask = await Task.WhenAny(dataAsteroid, dailyAstronomyImage);
                Console.WriteLine($"En hızlı çalısan API: {firstFinishedTask.Result.RequestMessage.RequestUri}\n");

                GetAstronomyImageAsync(responseImage);

                if (responseDataAsteroid.IsSuccessStatusCode)
                {
                    var contentTask = responseDataAsteroid.Content.ReadAsStringAsync();
                    contentTask.Wait();

                    var jsonData = JsonDocument.Parse(contentTask.Result);
                    var nasaResponse = JsonSerializer.Deserialize<NasaResponse>(jsonData);

                    if (nasaResponse == null)
                    {
                        return ServiceResult<NasaResponse>.Fail(
                            "Veri Hatası",
                            $"API'den veri gelmedi: {(int)responseDataAsteroid.StatusCode}");
                    }

                    Console.WriteLine("Data With Async\n");

                    if (nasaResponse?.NearEarthObjects != null)
                    {
                        foreach (var dateEntry in nasaResponse.NearEarthObjects)
                        {
                            Console.WriteLine($"Date: {dateEntry.Key}");
                            foreach (var obj in dateEntry.Value)
                            {
                                Console.WriteLine($"ID: {obj.Id}, Name: {obj.Name}");
                            }
                        }
                    }

                    return ServiceResult<NasaResponse>.Success(nasaResponse, (int)responseDataAsteroid.StatusCode);
                }
                else
                {
                    return ServiceResult<NasaResponse>.Fail(
                    "API Hatası",
                    $"API isteği başarısız oldu: {(int)responseDataAsteroid.StatusCode}");
                }
            }
        }

        public static async Task<ServiceResult<Apod>> GetAstronomyImageAsync(HttpResponseMessage responseImage)
        {
            if (responseImage.IsSuccessStatusCode)
            {
                var content = responseImage.Content.ReadAsStringAsync();
                content.Wait();

                var jsonDataImage = JsonDocument.Parse(content.Result);
                var imageResponse = JsonSerializer.Deserialize<Apod>(jsonDataImage);

                if (imageResponse == null)
                {
                    return ServiceResult<Apod>.Fail(
                        "Veri Hatası",
                        $"API'den veri gelmedi: {(int)responseImage.StatusCode}");

                }

                Console.WriteLine($"Title: {imageResponse.Title}, HD Image Url: {imageResponse.HdImageUrl}\n");

                return ServiceResult<Apod>.Success(imageResponse, (int)responseImage.StatusCode);
            }
            else
            {
                return ServiceResult<Apod>.Fail(
                   "API Hatası",
                   $"API isteği başarısız oldu: {(int)responseImage.StatusCode}");
            }
            
        }
    }
}
