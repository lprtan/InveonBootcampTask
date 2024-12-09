using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IveonBootcamp.Asynchronous
{
    public class TaskStaticMethodExample
    {
        //Verilen bir action'ı yeni bir thread'de çalıştırmak için kullanılır. Örnek olarak her bir count arttığında pogress bar ilerlemesini sağlanırken aynı zman UI donmaması için kullanılbilir.
        public static async Task CountProgresbarr()
        {
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    int progresbarPosition = 0;

                    if (progresbarPosition != 1000000)
                    {
                        progresbarPosition++;
                    }
                }
            });
        }


        //Eğer ki yapılacak işlem asenkron bir yaklaşım sergilemeyecek ve geriye Task tipinde bir değer döndürmemiz gerekecekse Task.FromResult metodunu kullanmamız yeterlidir.
        public static Task<int> FromResultMethod()
        {
            return Task.FromResult(123);
        }

        // Test senaryolarında veya görev oluşturmayı gerektiren ancak veri döndürmeyen durumlarda kullanılır.
        public static Task RamdomNumber()
        {
            Random random = new Random();
            int number = random.Next();
            Console.WriteLine(number);
            return Task.CompletedTask;
        }

        //Hata durumlarını simüle etmek için kullanılır
        public static Task<string> GetErrorAsync()
        {
            int number = -10;
            if (number < 0)
            {
                return Task.FromException<string>(new InvalidOperationException("Sayı negatif olamaz"));
            }

            return Task.FromResult(number.ToString());
        }

        //İptal senaryolarını test etmek için kullanılır
        public static Task CancellationAsync(CancellationToken cancellationToken)
        {
            return Task.FromCanceled(cancellationToken);
        }

        //Verilen bir action'ı yeni bir thread'de çalıştırmak için kullanılır. Örnek olarak her bir count arttığında pogress bar ilerlemesini sağlanırken aynı zman UI donmaması için kullanılbilir.

        public static async Task CountProgresbarr2()
        {
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    int progresbarPosition = 0;

                    if (progresbarPosition != 1000000)
                    {
                        progresbarPosition++;
                    }
                }
            });
        }

        //çalışmanın mevcut durumunu geri verir ve kodun geri kalan kısmı daha sonra, asenkron bir şekilde çalışmaya devam eder. 

        public static async Task FirstMethod()
        {
            Console.WriteLine("birinci metot başladı..");
            await Task.Yield();
            Console.WriteLine("Birinci metot devam ediyor...");
        }

        public static async Task SecondMethod()
        {
            Console.WriteLine("ikinci metot başladı...");
            await Task.Delay(1000);
            Console.WriteLine("İkinci metot devam ediyor...");
        }
    }
}
