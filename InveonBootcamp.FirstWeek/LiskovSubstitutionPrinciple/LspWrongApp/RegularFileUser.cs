using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.LiskovSubstitutionPrinciple.LspWrongApp
{
    public class RegularFileUser : AccessDataFile 
    {
        public override void ReadFile()
        {
            Console.WriteLine($"Kullanıcı {FilePath} dosyasını okudu.");
        }

        public override void WriteFile()
        {
            throw new NotImplementedException();
        }
    }
}
