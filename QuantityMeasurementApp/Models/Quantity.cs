using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementApp.Models
{
    public class Quantity<U>
    {
            private const double EPSILON = 0.0001;

            public double Value { get; }

            public U Unit { get; }

            public Quantity(double value, U unit)
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                    throw new ArgumentException("Invalid value");

                if (unit == null)
                    throw new ArgumentException("Unit cannot be null");

                Value = value;
                Unit = unit;
            }

            public override bool Equals(object? obj)
            {
                if (this == obj)
                    return true;

                if (obj == null || GetType() != obj.GetType())
                    return false;

                Quantity<U> other = (Quantity<U>)obj;

                if (Unit!.GetType() != other.Unit!.GetType())
                    return false;

                double base1 = ConvertToBase(Value, Unit);
                double base2 = ConvertToBase(other.Value, other.Unit);

                return Math.Abs(base1 - base2) < EPSILON;
            }

            public Quantity<U> ConvertTo(U targetUnit)
            {
                double baseValue = ConvertToBase(Value, Unit);

                double converted = ConvertFromBase(baseValue, targetUnit);

                return new Quantity<U>(converted, targetUnit);
            }

            public Quantity<U> Add(Quantity<U> other)
            {
                return Add(other, Unit);
            }

            public Quantity<U> Add(Quantity<U> other, U targetUnit)
            {
                double base1 = ConvertToBase(Value, Unit);
                double base2 = ConvertToBase(other.Value, other.Unit);

                double sum = base1 + base2;

                double result = ConvertFromBase(sum, targetUnit);

                return new Quantity<U>(result, targetUnit);
            }

            private double ConvertToBase(double value, U unit)
            {
                if (unit is LengthUnit lengthUnit)
                    return lengthUnit.ConvertToBaseUnit(value);

                if (unit is LengthUnitWM weightUnit)
                    return weightUnit.ConvertToBaseUnit(value);

               if (unit is LengthUnitVM volumeUnit)
                   return volumeUnit.ConvertToBaseUnit(value);

            throw new ArgumentException("Unsupported unit type");
            }

            private double ConvertFromBase(double value, U unit)
            {
                if (unit is LengthUnit lengthUnit)
                    return lengthUnit.ConvertFromBaseUnit(value);

                if (unit is LengthUnitWM weightUnit)
                    return weightUnit.ConvertFromBaseUnit(value);

                if (unit is LengthUnitVM volumeUnit)
                   return volumeUnit.ConvertFromBaseUnit(value);


            throw new ArgumentException("Unsupported unit type");
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Value, Unit);
            }

            public override string ToString()
            {
                return $"Quantity(Value={Value}, Unit={Unit})";
            }

        // Subtraction Methods

        public Quantity<U> Subtract(Quantity<U> other)
        {
            return Subtract(other, Unit);
        }

        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Other quantity cannot be null");

            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null");

            if (Unit!.GetType() != other.Unit!.GetType())
                throw new ArgumentException("Cross-category subtraction not allowed");

            double base1 = ConvertToBase(Value, Unit);
            double base2 = ConvertToBase(other.Value, other.Unit);

            double difference = base1 - base2;

            double result = ConvertFromBase(difference, targetUnit);

            // Round to 2 decimal places
            result = Math.Round(result, 2);

            return new Quantity<U>(result, targetUnit);
        }

        // Division Method

        public double Divide(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Other quantity cannot be null");

            if (Unit!.GetType() != other.Unit!.GetType())
                throw new ArgumentException("Cross-category division not allowed");

            double base1 = ConvertToBase(Value, Unit);
            double base2 = ConvertToBase(other.Value, other.Unit);

            if (Math.Abs(base2) < EPSILON)
                throw new ArithmeticException("Cannot divide by zero");

            return base1 / base2;
        }
    }
    }


