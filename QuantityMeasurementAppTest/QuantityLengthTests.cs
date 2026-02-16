using QuantityMeasurementApp.Models;

namespace QuantityMeasurementAppTest
{
    public class QuantityLengthTests
    {

        private const double EPSILON = 0.0001; //small number used when comparing floating-point numbers

        [Test]
        public void TestConversion_FeetToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Feet, LengthUnit.Inch);
            Assert.That(result, Is.EqualTo(12.0));
        }

        [Test]
        public void TestConversion_InchesToFeet()
        {
            double result = QuantityLength.Convert(24.0, LengthUnit.Inch, LengthUnit.Feet);
            Assert.That(result, Is.EqualTo(2.0));
        }

        [Test]
        public void TestConversion_YardsToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Yard, LengthUnit.Inch);
            Assert.That(result, Is.EqualTo(36.0));
        }

        [Test]
        public void TestConversion_InchesToYards()
        {
            double result = QuantityLength.Convert(72.0, LengthUnit.Inch, LengthUnit.Yard);
            Assert.That(result, Is.EqualTo(2.0));
        }

        [Test]
        public void TestConversion_FeetToYards()
        {
            double result = QuantityLength.Convert(6.0, LengthUnit.Feet, LengthUnit.Yard);
            Assert.That(result, Is.EqualTo(2.0));
        }

        [Test]
        public void TestConversion_CentimetersToInches()
        {
            double result = QuantityLength.Convert(2.54, LengthUnit.Centimeter, LengthUnit.Inch);
            Assert.That(result, Is.EqualTo(1.0).Within(EPSILON));
        }

        [Test]
        public void TestConversion_SameUnit_ReturnsSameValue()
        {
            double result = QuantityLength.Convert(5.0, LengthUnit.Feet, LengthUnit.Feet);
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void TestConversion_ZeroValue()
        {
            double result = QuantityLength.Convert(0.0, LengthUnit.Feet, LengthUnit.Inch);
            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void TestConversion_NegativeValue()
        {
            double result = QuantityLength.Convert(-1.0, LengthUnit.Feet, LengthUnit.Inch);
            Assert.That(result, Is.EqualTo(-12.0));
        }

        [Test]
        public void TestConversion_LargeValue()
        {
            double result = QuantityLength.Convert(1_000_000.0, LengthUnit.Feet, LengthUnit.Inch);
            Assert.That(result, Is.EqualTo(12_000_000.0));
        }

        [Test]
        public void TestConversion_SmallValue()
        {
            double result = QuantityLength.Convert(0.0001, LengthUnit.Feet, LengthUnit.Inch);
            Assert.That(result, Is.EqualTo(0.0012).Within(EPSILON));
        }


        [Test]
        public void TestConversion_RoundTrip_PreservesValue()
        {
            double original = 5.0;

            double toInches = QuantityLength.Convert(original, LengthUnit.Feet, LengthUnit.Inch);
            double backToFeet = QuantityLength.Convert(toInches, LengthUnit.Inch, LengthUnit.Feet);

            Assert.That(backToFeet, Is.EqualTo(original).Within(EPSILON));
        }

        [Test]
        public void TestConversion_Bidirectional()
        {
            double yards = 2.0;

            double feet = QuantityLength.Convert(yards, LengthUnit.Yard, LengthUnit.Feet);
            double backToYards = QuantityLength.Convert(feet, LengthUnit.Feet, LengthUnit.Yard);

            Assert.That(backToYards, Is.EqualTo(yards).Within(EPSILON));
        }

        [Test]
        public void TestConversion_InvalidValue_NaN_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                QuantityLength.Convert(double.NaN, LengthUnit.Feet, LengthUnit.Inch));
        }

        [Test]
        public void TestConversion_InvalidValue_Infinity_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                QuantityLength.Convert(double.PositiveInfinity, LengthUnit.Feet, LengthUnit.Inch));
        }


        [Test]
        public void TestConversion_MultiStepConsistency()
        {
            double original = 2.0; // yards

            double feet = QuantityLength.Convert(original, LengthUnit.Yard, LengthUnit.Feet);
            double inches = QuantityLength.Convert(feet, LengthUnit.Feet, LengthUnit.Inch);
            double backToYards = QuantityLength.Convert(inches, LengthUnit.Inch, LengthUnit.Yard);

            Assert.That(backToYards, Is.EqualTo(original).Within(EPSILON));
        }
    }
}

