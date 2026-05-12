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

        //  Arithmetic Operation Enum

        private enum ArithmeticOperation
        {
            ADD,
            SUBTRACT,
            DIVIDE
        }

        //  Public Add Methods

        public Quantity<U> Add(Quantity<U> other)
        {
            return Add(other, Unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            validateArithmeticOperands(other, targetUnit, true);

            double baseResult =
                performBaseArithmetic(other, ArithmeticOperation.ADD);

            double converted =
                ConvertFromBase(baseResult, targetUnit);

            converted = roundToTwoDecimals(converted);

            return new Quantity<U>(converted, targetUnit);
        }

        //  Public Subtract Methods

        public Quantity<U> Subtract(Quantity<U> other)
        {
            return Subtract(other, Unit);
        }

        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            validateArithmeticOperands(other, targetUnit, true);

            double baseResult =
                performBaseArithmetic(other, ArithmeticOperation.SUBTRACT);

            double converted =
                ConvertFromBase(baseResult, targetUnit);

            converted = roundToTwoDecimals(converted);

            return new Quantity<U>(converted, targetUnit);
        }

        //  Public Divide Method

        public double Divide(Quantity<U> other)
        {
            validateArithmeticOperands(other, default, false);

            return performBaseArithmetic(other,
                ArithmeticOperation.DIVIDE);
        }

        //  Centralized Validation Helper

        private void validateArithmeticOperands(
            Quantity<U> other,
            U targetUnit,
            bool targetUnitRequired)
        {
            if (other == null)
                throw new ArgumentException(
                    "Other quantity cannot be null");

            if (Unit == null || other.Unit == null)
                throw new ArgumentException(
                    "Unit cannot be null");

            if (Unit.GetType() != other.Unit.GetType())
                throw new ArgumentException(
                    "Cross-category arithmetic not allowed");

            if (double.IsNaN(Value) ||
                double.IsInfinity(Value) ||
                double.IsNaN(other.Value) ||
                double.IsInfinity(other.Value))
            {
                throw new ArgumentException(
                    "Values must be finite");
            }

            if (targetUnitRequired && targetUnit == null)
            {
                throw new ArgumentException(
                    "Target unit cannot be null");
            }
        }

        //  Centralized Arithmetic Helper

        private double performBaseArithmetic(
            Quantity<U> other,
            ArithmeticOperation operation)
        {
            double base1 = ConvertToBase(Value, Unit);
            double base2 = ConvertToBase(other.Value, other.Unit);

            return operation switch
            {
                ArithmeticOperation.ADD =>
                    base1 + base2,

                ArithmeticOperation.SUBTRACT =>
                    base1 - base2,

                ArithmeticOperation.DIVIDE =>
                    divideBaseValues(base1, base2),

                _ => throw new ArgumentException(
                    "Unsupported operation")
            };
        }

        //  Division Helper


        private double divideBaseValues(double a, double b)
        {
            if (Math.Abs(b) < EPSILON)
                throw new ArithmeticException(
                    "Cannot divide by zero");

            return a / b;
        }

        //  Rounding Helper

        private double roundToTwoDecimals(double value)
        {
            return Math.Round(value, 2);
        }

        //  Equality

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            Quantity<U> other = (Quantity<U>)obj;

            double base1 = ConvertToBase(Value, Unit);
            double base2 = ConvertToBase(other.Value, other.Unit);

            return Math.Abs(base1 - base2) < EPSILON;
        }

        //  Conversion

        public Quantity<U> ConvertTo(U targetUnit)
        {
            double baseValue = ConvertToBase(Value, Unit);

            double converted =
                ConvertFromBase(baseValue, targetUnit);

            return new Quantity<U>(converted, targetUnit);
        }

        //  Base Unit Conversion

        private double ConvertToBase(double value, U unit)
        {
            if (unit is LengthUnit lengthUnit)
                return lengthUnit.ConvertToBaseUnit(value);

            if (unit is LengthUnitWM weightUnit)
                return weightUnit.ConvertToBaseUnit(value);

            if (unit is LengthUnitVM volumeUnit)
                return volumeUnit.ConvertToBaseUnit(value);

            throw new ArgumentException(
                "Unsupported unit type");
        }

        private double ConvertFromBase(double value, U unit)
        {
            if (unit is LengthUnit lengthUnit)
                return lengthUnit.ConvertFromBaseUnit(value);

            if (unit is LengthUnitWM weightUnit)
                return weightUnit.ConvertFromBaseUnit(value);

            if (unit is LengthUnitVM volumeUnit)
                return volumeUnit.ConvertFromBaseUnit(value);

            throw new ArgumentException(
                "Unsupported unit type");
        }

        //  HashCode

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Unit);
        }

        //  ToString

        public override string ToString()
        {
            return $"Quantity(Value={Value}, Unit={Unit})";
        }

    }
}


