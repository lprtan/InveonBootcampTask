using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.FirstWeek.OpenClosedPrinciple.OcpWrongApp
{
    public enum AccountType
    {
        None,
        Regular,
        Salary,
        ChildSavings
    }
    public class Account
    {
        public static decimal Interest { get; set; }
        public static decimal CalculateInterest(AccountType accountType, int amount)
        {
            if (accountType == AccountType.Regular)
            {    
                Interest = amount * 0.4m;
                if (amount < 1000) Interest -= amount * 0.2m;
                if (amount < 50000) Interest += amount * 0.4m;

                return Interest;
            }
            else if (accountType == AccountType.Salary)
            {
                return Interest = amount * 0.5m;
            }
            else if (accountType == AccountType.Salary)
            {
                return Interest = amount * 0.2m;
            }

            return amount;
        }
    }
}
