using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Models
{
    public class QuantityLengthWM
    {

        public readonly double _value;
        public readonly LengthUnitWM _unit;


        public QuantityLengthWM(double value, LengthUnitWM unit)
        {
            if (double.IsNaN(value))
                throw new ArgumentException("Invalid value");

            _value = value;
            _unit = unit;
        }

        public bool Equals(QuantityLengthWM other)
        {
            if (other == null)
                return false;

            double base1 = _unit.ConvertToBaseUnit(_value);
            double base2 = other._unit.ConvertToBaseUnit(other._value);

            return Math.Abs(base1 - base2) < 0.0001;
        }

        public QuantityLengthWM ConvertTo(LengthUnitWM targetUnit)
        {
            double baseValue = _unit.ConvertToBaseUnit(_value);
            double converted = targetUnit.ConvertFromBaseUnit(baseValue);

            return new QuantityLengthWM(converted, targetUnit);
        }

        public QuantityLengthWM Add(QuantityLengthWM other, LengthUnitWM targetUnit)
        {
            double base1 = _unit.ConvertToBaseUnit(_value);
            double base2 = other._unit.ConvertToBaseUnit(other._value);

            double sum = base1 + base2;

            double result = targetUnit.ConvertFromBaseUnit(sum);

            return new QuantityLengthWM(result, targetUnit);
        }
    }
}
