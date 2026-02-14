using QuantityMeasurementApp.Models;

namespace QuantityMeasurementAppTest
{
    public class QuantityLengthTests
    {
        [Test]
        public void TestEquality_FeetToFeet_SameValue()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);
            var q2 = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.That(q1.Equals(q2), Is.True);
        }

        [Test]
        public void TestEquality_InchToInch_SameValue()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Inch);
            var q2 = new QuantityLength(1.0, LengthUnit.Inch);

            Assert.That(q1.Equals(q2), Is.True);
        }

        [Test]
        public void TestEquality_FeetToInch_Equivalent()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);
            var q2 = new QuantityLength(12.0, LengthUnit.Inch);

            Assert.That(q1.Equals(q2), Is.True);
        }

        [Test]
        public void TestEquality_InchToFeet_Equivalent()
        {
            var q1 = new QuantityLength(12.0, LengthUnit.Inch);
            var q2 = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.That(q1.Equals(q2), Is.True);
        }

        [Test]
        public void TestEquality_DifferentValue()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);
            var q2 = new QuantityLength(2.0, LengthUnit.Feet);

            Assert.That(q1.Equals(q2), Is.False);
        }

        [Test]
        public void TestEquality_NullComparison()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.That(q1.Equals(null), Is.False);
        }

        [Test]
        public void TestEquality_SameReference()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.That(q1.Equals(q1), Is.True);
        }

        [Test]
        public void Test_InvalidValue_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new QuantityLength(double.NaN, LengthUnit.Feet));
        }
    }
}

