using QuantityMeasurementApp.Models;

namespace QuantityMeasurementAppTest
{
      [TestFixture]
    public class QuantityLengthTests
    {
            private const double EPSILON = 0.001;

            // Length Equality Tests

            [Test]
            public void TestGenericQuantity_LengthEquality()
            {
                var a = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
                var b = new Quantity<LengthUnit>(12.0, LengthUnit.Inch);

                Assert.That(a.Equals(b), Is.True);
            }

            [Test]
            public void TestGenericQuantity_LengthInequality()
            {
                var a = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
                var b = new Quantity<LengthUnit>(2.0, LengthUnit.Feet);

                Assert.That(a.Equals(b), Is.False);
            }

            //  Weight Equality Tests
          
            [Test]
            public void TestGenericQuantity_WeightEquality()
            {
                var a = new Quantity<LengthUnitWM>(1.0, LengthUnitWM.Kilogram);
                var b = new Quantity<LengthUnitWM>(1000.0, LengthUnitWM.Gram);

                Assert.That(a.Equals(b), Is.True);
            }

            [Test]
            public void TestGenericQuantity_WeightPoundEquality()
            {
                var a = new Quantity<LengthUnitWM>(1.0, LengthUnitWM.Kilogram);
                var b = new Quantity<LengthUnitWM>(2.20462, LengthUnitWM.Pound);

                Assert.That(a.Equals(b), Is.True);
            }

            //  Conversion Tests

            [Test]
            public void TestGenericQuantity_LengthConversion()
            {
                var a = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);

                var result = a.ConvertTo(LengthUnit.Inch);

                Assert.That(result.Value, Is.EqualTo(12.0).Within(EPSILON));
            }

            [Test]
            public void TestGenericQuantity_WeightConversion()
            {
                var a = new Quantity<LengthUnitWM>(1.0, LengthUnitWM.Kilogram);

                var result = a.ConvertTo(LengthUnitWM.Gram);

                Assert.That(result.Value, Is.EqualTo(1000.0).Within(EPSILON));
            }

            //  Addition Tests

            [Test]
            public void TestGenericQuantity_LengthAddition()
            {
                var a = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
                var b = new Quantity<LengthUnit>(12.0, LengthUnit.Inch);

                var result = a.Add(b, LengthUnit.Feet);

                Assert.That(result.Value, Is.EqualTo(2.0).Within(EPSILON));
            }

            [Test]
            public void TestGenericQuantity_WeightAddition()
            {
                var a = new Quantity<LengthUnitWM>(1.0, LengthUnitWM.Kilogram);
                var b = new Quantity<LengthUnitWM>(1000.0, LengthUnitWM.Gram);

                var result = a.Add(b, LengthUnitWM.Kilogram);

                Assert.That(result.Value, Is.EqualTo(2.0).Within(EPSILON));
            }

            //  Cross Category Prevention

            [Test]
            public void TestCrossCategoryComparison_ShouldReturnFalse()
            {
                var length = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
                var weight = new Quantity<LengthUnitWM>(1.0, LengthUnitWM.Kilogram);

                Assert.That(length.Equals(weight), Is.False);
            }

            //  Constructor Validation

            [Test]
            public void TestConstructor_InvalidValue_ShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                    new Quantity<LengthUnit>(double.NaN, LengthUnit.Feet));
            }

            // Zero Value Tests

            [Test]
            public void TestZeroValue_Equality()
            {
                var a = new Quantity<LengthUnitWM>(0.0, LengthUnitWM.Kilogram);
                var b = new Quantity<LengthUnitWM>(0.0, LengthUnitWM.Gram);

                Assert.That(a.Equals(b), Is.True);
            }

            //  Negative Value Tests

            [Test]
            public void TestNegativeValue_Equality()
            {
                var a = new Quantity<LengthUnitWM>(-1.0, LengthUnitWM.Kilogram);
                var b = new Quantity<LengthUnitWM>(-1000.0, LengthUnitWM.Gram);

                Assert.That(a.Equals(b), Is.True);
            }

            //  Round Trip Conversion

            [Test]
            public void TestRoundTripConversion()
            {
                var a = new Quantity<LengthUnit>(1.5, LengthUnit.Feet);

                var result = a.ConvertTo(LengthUnit.Inch)
                              .ConvertTo(LengthUnit.Feet);

                Assert.That(result.Value, Is.EqualTo(1.5).Within(EPSILON));
            }

        }
    }



