using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Models
{
    public static class LengthUnitExtensionsWM
    {

        public static double ConvertToBaseUnit(this LengthUnitWM unit, double value)
        {
            return unit switch
            {
                LengthUnitWM.Kilogram => value,
                LengthUnitWM.Gram => value / 1000,
                LengthUnitWM.Pound => value * 0.453592,
                _ => throw new ArgumentException("Invalid unit")
            };
        }

        public static double ConvertFromBaseUnit(this LengthUnitWM unit, double baseValue)
        {
            return unit switch
            {
                LengthUnitWM.Kilogram => baseValue,
                LengthUnitWM.Gram => baseValue * 1000,
                LengthUnitWM.Pound => baseValue / 0.453592,
                _ => throw new ArgumentException("Invalid unit")
            };
        }

        public static string GetUnitName(this LengthUnitWM unit)
        {
            return unit.ToString();
        }
    }
}
