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

        private const double InchToFeet = 1.0 / 12.0;

        public QuantityLength(double value, LengthUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value.");

            _value = value;
            _unit = unit;
        }

        public double Value => _value;
        public LengthUnit Unit => _unit;

        private double ConvertToFeet()
        {
            return _unit switch
            {
                LengthUnit.Feet => _value,
                LengthUnit.Inch => _value * InchToFeet,
                _ => throw new ArgumentException("Unsupported unit"
                )
            };
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (QuantityLength)obj;

            return this.ConvertToFeet()
               .CompareTo(other.ConvertToFeet()) == 0;
        }

        public override int GetHashCode()
        {
            return ConvertToFeet().GetHashCode();
        }

    }
}
