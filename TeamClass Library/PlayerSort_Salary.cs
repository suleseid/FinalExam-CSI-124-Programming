using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamClass_Library
{
    public class PlayerSort_Salary : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return x.Salary.CompareTo(y.Salary);
        }
    }
}
