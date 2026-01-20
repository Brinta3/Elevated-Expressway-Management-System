using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEMS
{
    public class TollCalc
    {
        // Calculation
        public decimal CalculateToll(Vehicle v)
        {
            if (v is Car) return 100;
            if (v is Truck) return 150;
            if (v is Bus) return 120;
            if (v is Bike) return 50;

            throw new Exception("Unknown vehicle type");
        }
    }
}
