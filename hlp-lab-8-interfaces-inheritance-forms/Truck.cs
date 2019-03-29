using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hlp_lab_8_interfaces_inheritance_forms
{
    class Truck : Vehicle
    {
        public Truck(Truck truck) : base(truck) { }
        public Truck(String brand, int year, double price)
            : base(brand, year, price)
        { }

        public override double calculatePrice(double price)
        {
            int age = DateTime.Now.Year - this.Year;
            if (0 > age)
            {
                age = 0;
            }

            double multyplier;
            if (1 > age) {
                multyplier = 1;
            } else if (3 >= age) {
                multyplier = .9;
            } else if (10 >= age) {
                multyplier = .8;
            } else {
                multyplier = .7;
            }

            return multyplier * price;
        }
        public override object Clone()
        {
            return new Truck(this);
        }
    }
}
