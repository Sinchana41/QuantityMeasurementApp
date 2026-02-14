using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Models
{
    public class Inches
    {
        private readonly double _value;

        public Inches(double value)
        {

            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid measurement value");

            _value=value;
        }

        public double Value => _value;

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            Inches other = (Inches)obj;

            return _value.CompareTo(other._value) == 0;
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

    }
}
