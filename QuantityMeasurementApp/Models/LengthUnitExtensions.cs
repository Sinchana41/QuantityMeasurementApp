using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Models
{
    public static class LengthUnitExtensions
    {

        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            return unit switch
            {
                LengthUnit.Feet => value,
                LengthUnit.Inch => value / 12,
                LengthUnit.Yard => value * 3,
                LengthUnit.Centimeter => value / 30.48,
                _ => throw new ArgumentException("Invalid unit")
            };
        }

        public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
        {
            return unit switch
            {
                LengthUnit.Feet => baseValue,
                LengthUnit.Inch => baseValue * 12,
                LengthUnit.Yard => baseValue / 3,
                LengthUnit.Centimeter => baseValue * 30.48,
                _ => throw new ArgumentException("Invalid unit")
            };
        }

    }
}

