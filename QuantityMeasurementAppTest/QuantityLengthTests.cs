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

        // Conversion Tests

        [Test]
        public void TestConversion_LitreToMillilitre()
        {
            var a = new Quantity<LengthUnitVM>(1.0, LengthUnitVM.Litre);

            var result = a.ConvertTo(LengthUnitVM.Millilitre);

            Assert.That(result.Value,
                Is.EqualTo(1000.0).Within(EPSILON));
        }

        [Test]
        public void TestConversion_MillilitreToLitre()
        {
            var a = new Quantity<LengthUnitVM>(1000.0, LengthUnitVM.Millilitre);

            var result = a.ConvertTo(LengthUnitVM.Litre);

            Assert.That(result.Value,
                Is.EqualTo(1.0).Within(EPSILON));
        }

        [Test]
        public void TestConversion_GallonToLitre()
        {
            var a = new Quantity<LengthUnitVM>(1.0, LengthUnitVM.Gallon);

            var result = a.ConvertTo(LengthUnitVM.Litre);

            Assert.That(result.Value,
                Is.EqualTo(3.78541).Within(0.01));
        }

        [Test]
        public void TestConversion_LitreToGallon()
        {
            var a = new Quantity<LengthUnitVM>(3.78541, LengthUnitVM.Litre);

            var result = a.ConvertTo(LengthUnitVM.Gallon);

            Assert.That(result.Value,
                Is.EqualTo(1.0).Within(0.01));
        }

        // Addition Tests

        [Test]
        public void TestAddition_LitrePlusLitre()
        {
            var a = new Quantity<LengthUnitVM>(1.0, LengthUnitVM.Litre);
            var b = new Quantity<LengthUnitVM>(2.0, LengthUnitVM.Litre);

            var result = a.Add(b);

            Assert.That(result.Value,
                Is.EqualTo(3.0).Within(EPSILON));
        }

        [Test]
        public void TestAddition_LitrePlusMillilitre()
        {
            var a = new Quantity<LengthUnitVM>(1.0, LengthUnitVM.Litre);
            var b = new Quantity<LengthUnitVM>(1000.0, LengthUnitVM.Millilitre);

            var result = a.Add(b);

            Assert.That(result.Value,
                Is.EqualTo(2.0).Within(EPSILON));
        }

        [Test]
        public void TestAddition_ExplicitTargetUnit()
        {
            var a = new Quantity<LengthUnitVM>(1.0, LengthUnitVM.Litre);
            var b = new Quantity<LengthUnitVM>(1000.0, LengthUnitVM.Millilitre);

            var result = a.Add(b, LengthUnitVM.Millilitre);

            Assert.That(result.Value,
                Is.EqualTo(2000.0).Within(EPSILON));
        }

        [Test]
        public void TestAddition_GallonPlusLitre()
        {
            var a = new Quantity<LengthUnitVM>(1.0, LengthUnitVM.Gallon);
            var b = new Quantity<LengthUnitVM>(3.78541, LengthUnitVM.Litre);

            var result = a.Add(b, LengthUnitVM.Gallon);

            Assert.That(result.Value,
                Is.EqualTo(2.0).Within(0.01));
        }

        [Test]
        public void TestSubtraction_SameUnit_FeetMinusFeet()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);

            var result = a.Subtract(b);

            Assert.That(result.Value,
                Is.EqualTo(5.0).Within(EPSILON));

            Assert.That(result.Unit,
                Is.EqualTo(LengthUnit.Feet));
        }

        [Test]
        public void TestSubtraction_CrossUnit_FeetMinusInches()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(6.0, LengthUnit.Inch);

            var result = a.Subtract(b);

            Assert.That(result.Value,
                Is.EqualTo(9.5).Within(EPSILON));

            Assert.That(result.Unit,
                Is.EqualTo(LengthUnit.Feet));
        }

        [Test]
        public void TestSubtraction_ExplicitTargetUnit_Inches()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(6.0, LengthUnit.Inch);

            var result = a.Subtract(b, LengthUnit.Inch);

            Assert.That(result.Value,
                Is.EqualTo(114.0).Within(EPSILON));

            Assert.That(result.Unit,
                Is.EqualTo(LengthUnit.Inch));
        }

        [Test]
        public void TestSubtraction_ResultingInNegative()
        {
            var a = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);

            var result = a.Subtract(b);

            Assert.That(result.Value,
                Is.EqualTo(-5.0).Within(EPSILON));
        }

        [Test]
        public void TestSubtraction_ResultingInZero()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(120.0, LengthUnit.Inch);

            var result = a.Subtract(b);

            Assert.That(result.Value,
                Is.EqualTo(0.0).Within(EPSILON));
        }

        [Test]
        public void TestSubtraction_WithZeroOperand()
        {
            var a = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(0.0, LengthUnit.Inch);

            var result = a.Subtract(b);

            Assert.That(result.Value,
                Is.EqualTo(5.0).Within(EPSILON));
        }

        [Test]
        public void TestSubtraction_WithNegativeValues()
        {
            var a = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(-2.0, LengthUnit.Feet);

            var result = a.Subtract(b);

            Assert.That(result.Value,
                Is.EqualTo(7.0).Within(EPSILON));
        }

        [Test]
        public void TestSubtraction_NonCommutative()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);

            var result1 = a.Subtract(b);
            var result2 = b.Subtract(a);

            Assert.That(result1.Value,
                Is.Not.EqualTo(result2.Value));
        }

        [Test]
        public void TestSubtraction_NullOperand()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);

            Assert.Throws<ArgumentException>(() =>
                a.Subtract(null));
        }

        [Test]
        public void TestSubtraction_CrossCategory()
        {
            var length =
                new Quantity<LengthUnit>(10.0, LengthUnit.Feet);

            var weight =
                new Quantity<LengthUnitWM>(5.0, LengthUnitWM.Kilogram);

            Assert.That(length.Equals(weight), Is.False);
        }

        [Test]
        public void TestSubtraction_ChainedOperations()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(2.0, LengthUnit.Feet);
            var c = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);

            var result = a.Subtract(b).Subtract(c);

            Assert.That(result.Value,
                Is.EqualTo(7.0).Within(EPSILON));
        }

        // DIVISION TESTS

        [Test]
        public void TestDivision_SameUnit()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(2.0, LengthUnit.Feet);

            double result = a.Divide(b);

            Assert.That(result,
                Is.EqualTo(5.0).Within(EPSILON));
        }

        [Test]
        public void TestDivision_CrossUnit()
        {
            var a = new Quantity<LengthUnit>(24.0, LengthUnit.Inch);
            var b = new Quantity<LengthUnit>(2.0, LengthUnit.Feet);

            double result = a.Divide(b);

            Assert.That(result,
                Is.EqualTo(1.0).Within(EPSILON));
        }

        [Test]
        public void TestDivision_RatioGreaterThanOne()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(2.0, LengthUnit.Feet);

            double result = a.Divide(b);

            Assert.That(result,
                Is.GreaterThan(1.0));
        }

        [Test]
        public void TestDivision_RatioLessThanOne()
        {
            var a = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);

            double result = a.Divide(b);

            Assert.That(result,
                Is.EqualTo(0.5).Within(EPSILON));
        }

        [Test]
        public void TestDivision_RatioEqualToOne()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);

            double result = a.Divide(b);

            Assert.That(result,
                Is.EqualTo(1.0).Within(EPSILON));
        }

        [Test]
        public void TestDivision_NonCommutative()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);

            double result1 = a.Divide(b);
            double result2 = b.Divide(a);

            Assert.That(result1,
                Is.Not.EqualTo(result2));
        }

        [Test]
        public void TestDivision_ByZero()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);

            var zero =
                new Quantity<LengthUnit>(0.0, LengthUnit.Feet);

            Assert.Throws<ArithmeticException>(() =>
                a.Divide(zero));
        }

        [Test]
        public void TestDivision_WithLargeRatio()
        {
            var a =
                new Quantity<LengthUnitWM>(1000000.0,
                    LengthUnitWM.Kilogram);

            var b =
                new Quantity<LengthUnitWM>(1.0,
                    LengthUnitWM.Kilogram);

            double result = a.Divide(b);

            Assert.That(result,
                Is.EqualTo(1000000.0).Within(EPSILON));
        }

        [Test]
        public void TestDivision_WithSmallRatio()
        {
            var a =
                new Quantity<LengthUnitWM>(1.0,
                   LengthUnitWM.Kilogram);

            var b =
                new Quantity<LengthUnitWM>(1000000.0,
                    LengthUnitWM.Kilogram);

            double result = a.Divide(b);

            Assert.That(result,
                Is.EqualTo(0.000001).Within(0.0000001));
        }

        [Test]
        public void TestDivision_NullOperand()
        {
            var a =
                new Quantity<LengthUnit>(10.0,
                    LengthUnit.Feet);

            Assert.Throws<ArgumentException>(() =>
                a.Divide(null));
        }

        // 🔹 INTEGRATION TESTS

        [Test]
        public void TestSubtractionAddition_Inverse()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);

            var result = a.Add(b).Subtract(b);

            Assert.That(result.Value,
                Is.EqualTo(a.Value).Within(EPSILON));
        }

        [Test]
        public void TestSubtraction_Immutability()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);

            a.Subtract(b);

            Assert.That(a.Value,
                Is.EqualTo(10.0));

            Assert.That(b.Value,
                Is.EqualTo(5.0));
        }

        [Test]
        public void TestDivision_Immutability()
        {
            var a = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(5.0, LengthUnit.Feet);

            a.Divide(b);

            Assert.That(a.Value,
                Is.EqualTo(10.0));

            Assert.That(b.Value,
                Is.EqualTo(5.0));
        }
    }
}



