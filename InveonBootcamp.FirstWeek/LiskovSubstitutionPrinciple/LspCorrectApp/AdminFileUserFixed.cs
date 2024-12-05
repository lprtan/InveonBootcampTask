using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.LiskovSubstitutionPrinciple.LspCorrectApp
{
    public class AdminFileUserFixed : IFileWriter, IFileReader
    {
        public void FileWrite(string filePath)
        {
            Console.WriteLine($"Admin {filePath} dosyasını yazdırdı."); ;
        }

        public void ReadFile(string filePath)
        {
            Console.WriteLine($"Admin {filePath} dosyasını okudu.");
        }
    }
}
