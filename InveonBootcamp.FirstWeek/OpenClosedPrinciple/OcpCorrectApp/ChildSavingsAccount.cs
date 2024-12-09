using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.OpenClosedPrinciple.OcpCorrectApp
{
    public class ChildSavingsAccount : IAccount
    {
        public decimal CalculateInterest(int amount)
        {
            return amount * 0.2m; 
        }
    }
}
