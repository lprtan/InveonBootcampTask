using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.SingleResponsibilityPrinciple.SrpCorrectApp
{
    public interface IMediator
    {
        void Notify(string action, Employee employee);
    }
}
