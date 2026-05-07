using QuantityMeasurementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantityMeasurementAppTest
{
    [TestFixture]
    public class QuantityLengthWMTests
    {
            private const double EPSILON = 0.001;

            // =========================================
            // 🔹 Equality Tests
            // =========================================

            [Test]
            public void TestEquality_KilogramToKilogram_SameValue()
            {
                var a = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);
                var b = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);

                Assert.That(a.Equals(b), Is.True);
            }

            [Test]
            public void TestEquality_KilogramToKilogram_DifferentValue()
            {
                var a = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);
                var b = new QuantityLengthWM(2.0, LengthUnitWM.Kilogram);

                Assert.That(a.Equals(b), Is.False);
            }

            [Test]
            public void TestEquality_KilogramToGram_EquivalentValue()
            {
                var a = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);
                var b = new QuantityLengthWM(1000.0, LengthUnitWM.Gram);

                Assert.That(a.Equals(b), Is.True);
            }

            [Test]
            public void TestEquality_GramToPound_EquivalentValue()
            {
                var a = new QuantityLengthWM(453.592, LengthUnitWM.Gram);
                var b = new QuantityLengthWM(1.0, LengthUnitWM.Pound);

                Assert.That(a.Equals(b), Is.True);
            }

            [Test]
            public void TestEquality_NullComparison()
            {
                var a = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);

                Assert.That(a.Equals(null), Is.False);
            }

            [Test]
            public void TestEquality_SameReference()
            {
                var a = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);

                Assert.That(a.Equals(a), Is.True);
            }

            // =========================================
            // 🔹 Conversion Tests
            // =========================================

            [Test]
            public void TestConversion_KilogramToGram()
            {
                var a = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);

                var result = a.ConvertTo(LengthUnitWM.Gram);

                Assert.That(result._value, Is.EqualTo(1000.0).Within(EPSILON));
            }

            [Test]
            public void TestConversion_KilogramToPound()
            {
                var a = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);

                var result = a.ConvertTo(LengthUnitWM.Pound);

                Assert.That(result._value, Is.EqualTo(2.20462).Within(0.01));
            }

            [Test]
            public void TestConversion_PoundToKilogram()
            {
                var a = new QuantityLengthWM(2.20462, LengthUnitWM.Pound);

                var result = a.ConvertTo(LengthUnitWM.Kilogram);

                Assert.That(result._value, Is.EqualTo(1.0).Within(0.01));
            }

            [Test]
            public void TestConversion_RoundTrip()
            {
                var a = new QuantityLengthWM(1.5, LengthUnitWM.Kilogram);

                var result = a.ConvertTo(LengthUnitWM.Gram)
                              .ConvertTo(LengthUnitWM.Kilogram);

                Assert.That(result._value, Is.EqualTo(1.5).Within(EPSILON));
            }

            // =========================================
            // 🔹 Addition Tests
            // =========================================

            [Test]
            public void TestAddition_SameUnit()
            {
                var a = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);
                var b = new QuantityLengthWM(2.0, LengthUnitWM.Kilogram);

                var result = a.Add(b, LengthUnitWM.Kilogram);

                Assert.That(result._value, Is.EqualTo(3.0).Within(EPSILON));
            }

            [Test]
            public void TestAddition_CrossUnit_KilogramAndGram()
            {
                var a = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);
                var b = new QuantityLengthWM(1000.0, LengthUnitWM.Gram);

                var result = a.Add(b, LengthUnitWM.Kilogram);

                Assert.That(result._value, Is.EqualTo(2.0).Within(EPSILON));
            }

            [Test]
            public void TestAddition_ExplicitTargetUnit_Gram()
            {
                var a = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);
                var b = new QuantityLengthWM(1000.0, LengthUnitWM.Gram);

                var result = a.Add(b, LengthUnitWM.Gram);

                Assert.That(result._value, Is.EqualTo(2000.0).Within(EPSILON));
            }

            [Test]
            public void TestAddition_PoundAndKilogram()
            {
                var a = new QuantityLengthWM(2.20462, LengthUnitWM.Pound);
                var b = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);

                var result = a.Add(b, LengthUnitWM.Pound);

                Assert.That(result._value, Is.EqualTo(4.40924).Within(0.01));
            }

            [Test]
            public void TestAddition_WithZero()
            {
                var a = new QuantityLengthWM(5.0, LengthUnitWM.Kilogram);
                var zero = new QuantityLengthWM(0.0, LengthUnitWM.Gram);

                var result = a.Add(zero, LengthUnitWM.Kilogram);

                Assert.That(result._value, Is.EqualTo(5.0).Within(EPSILON));
            }

            [Test]
            public void TestAddition_NegativeValues()
            {
                var a = new QuantityLengthWM(5.0, LengthUnitWM.Kilogram);
                var b = new QuantityLengthWM(-2000.0, LengthUnitWM.Gram);

                var result = a.Add(b, LengthUnitWM.Kilogram);

                Assert.That(result._value, Is.EqualTo(3.0).Within(EPSILON));
            }

            // =========================================
            // 🔹 Edge Case Tests
            // =========================================

            [Test]
            public void TestEquality_ZeroValue()
            {
                var a = new QuantityLengthWM(0.0, LengthUnitWM.Kilogram);
                var b = new QuantityLengthWM(0.0, LengthUnitWM.Gram);

                Assert.That(a.Equals(b), Is.True);
            }

            [Test]
            public void TestEquality_NegativeWeight()
            {
                var a = new QuantityLengthWM(-1.0, LengthUnitWM.Kilogram);
                var b = new QuantityLengthWM(-1000.0, LengthUnitWM.Gram);

                Assert.That(a.Equals(b), Is.True);
            }

            [Test]
            public void TestEquality_LargeWeightValue()
            {
                var a = new QuantityLengthWM(1000000.0, LengthUnitWM.Gram);
                var b = new QuantityLengthWM(1000.0, LengthUnitWM.Kilogram);

                Assert.That(a.Equals(b), Is.True);
            }

            // =========================================
            // 🔹 Exception Tests
            // =========================================

            [Test]
            public void TestInvalidValue_ShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                    new QuantityLengthWM(double.NaN, LengthUnitWM.Kilogram));
            }

            [Test]
            public void TestInvalidUnit_ShouldThrowException()
            {
                var a = new QuantityLengthWM(1.0, LengthUnitWM.Kilogram);

                Assert.Throws<ArgumentException>(() =>
                    a.ConvertTo((LengthUnitWM)999));
            }
        }
    }




