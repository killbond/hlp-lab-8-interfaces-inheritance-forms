using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hlp_lab_8_interfaces_inheritance_forms
{
    abstract class Vehicle : ICloneable, IComparable<Vehicle>
    {
        private String brand;

        private int year;

        private double price;

        private double cost;

        public Vehicle(Vehicle vehicle)
        {
            Brand = vehicle.Brand;
            Year = vehicle.Year;
            Price = vehicle.Price;
        }

        public Vehicle(String brand, int year, double price)
        {
            this.Brand = brand;
            this.Year = year;
            this.Price = price;
        }

        public String Brand
        {
            get
            {
                return brand;
            }
            set
            {
                if ("" == value)
                {
                    throw new Exception("Brand cannot be blank");
                }
                brand = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (1900 > value || 2100 < value) 
                {
                    throw new Exception("Invalid year");
                }

                year = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (0 > value)
                {
                    throw new Exception("Invalid price");
                }
                price = value;
                cost = calculatePrice(value);
            }
        }

        public double Cost
        {
            get
            {
                return cost;
            }
        }

        public abstract double calculatePrice(double price);

        public abstract object Clone();

        public override bool Equals(object obj)
        {
            return this.year == (obj as Vehicle).year && 
                this.brand == (obj as Vehicle).brand;
        }

        public int CompareTo(Vehicle other)
        {
            if (this.Cost < other.Cost)
                return 1;
            if (this.Cost > other.Cost)
                return -1;
            else return 0;
        }
    }
}
