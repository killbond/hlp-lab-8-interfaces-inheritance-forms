using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hlp_lab_8_interfaces_inheritance_forms
{
    class Car : Vehicle
    {
        public Car(Car car) : base(car) { }

        public Car(String brand, int year, double price)
            : base(brand, year, price)
        { }

        public override double calculatePrice(double price)
        {
            int age = DateTime.Now.Year - this.Year;
            if (0 > age)
            {
                age = 0;
            }

            return price * Math.Pow(.9, age);
        }
        public override object Clone()
        {
            return new Car(this);
        }
    }
}
