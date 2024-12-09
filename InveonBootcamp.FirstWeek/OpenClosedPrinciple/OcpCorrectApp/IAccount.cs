using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.OpenClosedPrinciple.OcpCorrectApp
{
    public interface IAccount
    {
        decimal CalculateInterest(int amount);
    }
}
