using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Models
{
    public static class LengthUnitExtensions
    {

        public static double ToInchesFactor(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.Feet => 12.0,
                LengthUnit.Inch => 1.0,
                LengthUnit.Yard => 36.0,
                LengthUnit.Centimeter => 0.393701,
                _ => throw new ArgumentOutOfRangeException(nameof(unit))
            };
        }
    }
}

