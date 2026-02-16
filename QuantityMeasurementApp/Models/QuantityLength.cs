using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Models
{
    public class QuantityLength
    {

        private readonly double _value;
        private readonly LengthUnit _unit;

        public QuantityLength(double value, LengthUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value.");

            _value = value;
            _unit = unit;
        }

        public double Value => _value;
        public LengthUnit Unit => _unit;

        private double ConvertToInches()
        {
            return _unit switch
            {
                LengthUnit.Feet => _value * 12,  //1 foot = 12 inches
                LengthUnit.Inch => _value,      
                LengthUnit.Yard => _value * 36,  //1 yard = 36 inches
                LengthUnit.Centimeter => _value * 0.393701,   //  1 cm = 0.393701 inches
                _ => throw new ArgumentOutOfRangeException(nameof(_unit), "Unsupported unit")
            };
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (QuantityLength)obj;

            return ConvertToInches()
                   .CompareTo(other.ConvertToInches()) == 0;
        }

        public override int GetHashCode()
        {
            return ConvertToInches().GetHashCode();
        }
    }
}
