using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.LiskovSubstitutionPrinciple.LspCorrectApp
{
    internal interface IFileReader
    {
        void ReadFile(string filePath);
    }
}
