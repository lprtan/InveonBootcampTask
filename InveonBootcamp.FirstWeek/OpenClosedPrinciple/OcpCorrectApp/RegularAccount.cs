using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.OpenClosedPrinciple.OcpCorrectApp
{
    public class RegularAccount : IAccount
    {
        public decimal CalculateInterest(int amount)
        {
            decimal interest = 0;
            interest = amount * 0.4m;
            if (amount < 1000) interest -= amount * 0.2m;
            if (amount < 50000) interest += amount * 0.4m;

            return interest;
        }
    }
}
