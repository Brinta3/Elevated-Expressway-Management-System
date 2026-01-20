using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEMS
{
    // Abstract class
    public abstract class Vehicle
    {
        public required string VehicleId { get; set; }  
        public DateTime EntryTime { get; set; }
        public bool TollStatus { get; set; }

        public TollCalc TollCalculator { get; set; } = new TollCalc();

        // Calculate toll by TollCalc
        public decimal CalculateToll()
        {
            return TollCalculator.CalculateToll(this);
        }
    }
}

