using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Models
{
    public  static class LengthUnitExtensionsVM
    {
        public static double ConvertToBaseUnit(this LengthUnitVM unit, double value)
        {
            return unit switch
            {
                LengthUnitVM.Litre => value,
                LengthUnitVM.Millilitre => value * 0.001,
                LengthUnitVM.Gallon => value * 3.78541,
                _ => throw new ArgumentException("Invalid volume unit")
            };
        }

        public static double ConvertFromBaseUnit(this LengthUnitVM unit, double baseValue)
        {
            return unit switch
            {
                LengthUnitVM.Litre => baseValue,
                LengthUnitVM.Millilitre => baseValue * 1000,
                LengthUnitVM.Gallon => baseValue / 3.78541,
                _ => throw new ArgumentException("Invalid volume unit")
            };
        }

        public static string GetUnitName(this LengthUnitVM unit)
        {
            return unit.ToString();
        }
    }
}
