using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Models
{
    public interface IMeasurable
    {
        double ConvertToBaseUnit(double value);

        double ConvertFromBaseUnit(double baseValue);

        string GetUnitName();
    }
}
