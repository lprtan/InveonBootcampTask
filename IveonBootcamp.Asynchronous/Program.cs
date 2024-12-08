
using IveonBootcamp.Asynchronous;
using IveonBootcamp.Asynchronous.Services;

await ServiceAstroidInfoAsync.GetAstoridDataAsync();

Console.WriteLine("\nData With Sync\n");


ServiceAstroidInfo.GetAstoridDataSync();


#region Task sınıfı statik metotlsrı örnek sernaryolar üzerinden kullanımı
await TaskStaticMethodExample.FirstMethod(); 
Console.WriteLine("Birinci metot tamamlandı."); 
await TaskStaticMethodExample.SecondMethod();
Console.WriteLine("İkinci metot tamamlandı.");

// NOT: Task.WhenAny, Task.WhenAll, Task.Delay metotları ServiceAstroidInfoAsync içinde kullanılmıştır.
#endregion


Console.ReadKey();