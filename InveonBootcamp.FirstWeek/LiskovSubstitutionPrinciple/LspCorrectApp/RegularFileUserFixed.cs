using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.LiskovSubstitutionPrinciple.LspCorrectApp
{
    public class RegularFileUserFixed : IFileReader
    {
        public void ReadFile(string filePath)
        {
            Console.WriteLine($"Kullanıcı {filePath} dosyasını okudu.");
        }
    }
}
