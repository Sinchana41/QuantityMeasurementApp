using QuantityMeasurementApp.Models;

namespace QuantityMeasurementAppTest
{
      [TestFixture]
    public class QuantityLengthTests
    {

        private const double EPSILON = 0.001;

        // ===============================
        // 🔹 LengthUnit Enum Tests
        // ===============================

        [Test]
        public void LengthUnit_FeetConversionFactor()
        {
            double result = LengthUnit.Feet.ConvertToBaseUnit(5.0);
            Assert.That(result, Is.EqualTo(5.0).Within(EPSILON));
        }

        [Test]
        public void LengthUnit_InchToFeet()
        {
            double result = LengthUnit.Inch.ConvertToBaseUnit(12.0);
            Assert.That(result, Is.EqualTo(1.0).Within(EPSILON));
        }

        [Test]
        public void LengthUnit_YardToFeet()
        {
            double result = LengthUnit.Yard.ConvertToBaseUnit(1.0);
            Assert.That(result, Is.EqualTo(3.0).Within(EPSILON));
        }

        [Test]
        public void LengthUnit_CentimeterToFeet()
        {
            double result = LengthUnit.Centimeter.ConvertToBaseUnit(30.48);
            Assert.That(result, Is.EqualTo(1.0).Within(EPSILON));
        }

        // ===============================
        // 🔹 Convert From Base Unit
        // ===============================

        [Test]
        public void ConvertFromBaseUnit_FeetToInch()
        {
            double result = LengthUnit.Inch.ConvertFromBaseUnit(1.0);
            Assert.That(result, Is.EqualTo(12.0).Within(EPSILON));
        }

        [Test]
        public void ConvertFromBaseUnit_FeetToYard()
        {
            double result = LengthUnit.Yard.ConvertFromBaseUnit(3.0);
            Assert.That(result, Is.EqualTo(1.0).Within(EPSILON));
        }

        [Test]
        public void ConvertFromBaseUnit_FeetToCentimeter()
        {
            double result = LengthUnit.Centimeter.ConvertFromBaseUnit(1.0);
            Assert.That(result, Is.EqualTo(30.48).Within(EPSILON));
        }

        // ===============================
        // 🔹 Equality Tests
        // ===============================

        [Test]
        public void QuantityLength_Equality_FeetAndInches()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void QuantityLength_Equality_InchesAndYards()
        {
            var a = new QuantityLength(36.0, LengthUnit.Inch);
            var b = new QuantityLength(1.0, LengthUnit.Yard);

            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void QuantityLength_Equality_DifferentValues()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(2.0, LengthUnit.Feet);

            Assert.That(a.Equals(b), Is.False);
        }

        // ===============================
        // 🔹 ConvertTo Tests
        // ===============================

        [Test]
        public void ConvertTo_FeetToInches()
        {
            var q = new QuantityLength(1.0, LengthUnit.Feet);

            var result = q.ConvertTo(LengthUnit.Inch);

            Assert.That(result._value, Is.EqualTo(12.0).Within(EPSILON));
        }

        [Test]
        public void ConvertTo_CentimeterToInch()
        {
            var q = new QuantityLength(2.54, LengthUnit.Centimeter);

            var result = q.ConvertTo(LengthUnit.Inch);

            Assert.That(result._value, Is.EqualTo(1.0).Within(0.01));
        }

        // ===============================
        // 🔹 Addition Tests
        // ===============================

        [Test]
        public void Add_FeetAndInches_ResultInFeet()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            var result = a.Add(b, LengthUnit.Feet);

            Assert.That(result._value, Is.EqualTo(2.0).Within(EPSILON));
        }

        [Test]
        public void Add_FeetAndInches_ResultInYards()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            var result = a.Add(b, LengthUnit.Yard);

            Assert.That(result._value, Is.EqualTo(0.667).Within(0.01));
        }

        [Test]
        public void Add_WithZero_ShouldReturnSame()
        {
            var a = new QuantityLength(5.0, LengthUnit.Feet);
            var zero = new QuantityLength(0.0, LengthUnit.Inch);

            var result = a.Add(zero, LengthUnit.Feet);

            Assert.That(result._value, Is.EqualTo(5.0).Within(EPSILON));
        }

        [Test]
        public void Add_Commutativity()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            var r1 = a.Add(b, LengthUnit.Feet);
            var r2 = b.Add(a, LengthUnit.Feet);

            Assert.That(r1._value, Is.EqualTo(r2._value).Within(EPSILON));
        }

        // ===============================
        // 🔹 Exception Tests
        // ===============================

        [Test]
        public void InvalidValue_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
                new QuantityLength(double.NaN, LengthUnit.Feet));
        }

        [Test]
        public void InvalidUnit_ShouldThrowException()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.Throws<ArgumentException>(() =>
                a.Add(b, (LengthUnit)999));
        }

    }
}

