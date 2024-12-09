using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.LiskovSubstitutionPrinciple.LspWrongApp
{
    public class AdminUserFile : AccessDataFile
    {
        public override void ReadFile()
        {
            Console.WriteLine($"Admin {FilePath} dosyasını okudu.");
        }

        public override void WriteFile()
        {
            Console.WriteLine($"Admin {FilePath} dosyasını yazdırdı.");
        }
    }
}
