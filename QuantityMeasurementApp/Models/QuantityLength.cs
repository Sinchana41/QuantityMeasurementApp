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

        public static double Convert(double value, LengthUnit source, LengthUnit target)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value.");

            if (!Enum.IsDefined(typeof(LengthUnit), source) ||
                !Enum.IsDefined(typeof(LengthUnit), target))
                throw new ArgumentException("Invalid unit.");

            double valueInInches = value * source.ToInchesFactor();
            return valueInInches / target.ToInchesFactor();
        }
        
        public QuantityLength ConvertTo(LengthUnit targetUnit)
        {
            double convertedValue = Convert(_value, _unit, targetUnit);
            return new QuantityLength(convertedValue, targetUnit);
        }
        
        public QuantityLength Add(QuantityLength other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (double.IsNaN(_value) || double.IsInfinity(_value) ||
                double.IsNaN(other._value) || double.IsInfinity(other._value))
                throw new ArgumentException("Invalid numeric value.");

            // Convert both to base unit (inches)
            double thisInInches = _value * _unit.ToInchesFactor();
            double otherInInches = other._value * other._unit.ToInchesFactor();

            // Add
            double sumInInches = thisInInches + otherInInches;

            // Convert back to unit of FIRST operand
            double resultValue = sumInInches / _unit.ToInchesFactor();

            return new QuantityLength(resultValue, _unit);
        }

    }
}
