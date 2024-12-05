using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.LiskovSubstitutionPrinciple.LspWrongApp
{
    public class AccessDataFile
    {
        public string FilePath { get; set; }

        public virtual void ReadFile()
        {
            Console.WriteLine($"{FilePath} Dosyası Okundu.");
        }
        public virtual void WriteFile()
        {
            Console.WriteLine($"{FilePath} dosyasına yazdırıldı.");
        }
    }
}
