using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hlp_lab_8_interfaces_inheritance_forms
{
    class YearComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x.Year < y.Year)
                return 1;
            if (x.Year > y.Year)
                return -1;
            else return 0;
        }
    }
}
