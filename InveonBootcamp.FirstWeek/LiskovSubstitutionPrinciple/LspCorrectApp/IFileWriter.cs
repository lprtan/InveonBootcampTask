using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.LiskovSubstitutionPrinciple.LspCorrectApp
{
    public interface IFileWriter
    {
        void FileWrite(string filePath);
    }
}
