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
        public void TestEquality_YardToYard_SameValue()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Yard);
            var q2 = new QuantityLength(1.0, LengthUnit.Yard);

            Assert.That(q1.Equals(q2), Is.True);
        }

        [Test]
        public void TestEquality_YardToFeet_EquivalentValue()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            var feet = new QuantityLength(3.0, LengthUnit.Feet);

            Assert.That(yard.Equals(feet), Is.True);
        }

        [Test]
        public void TestEquality_YardToInches_EquivalentValue()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            var inches = new QuantityLength(36.0, LengthUnit.Inch);

            Assert.That(yard.Equals(inches), Is.True);
        }


        [Test]
        public void TestEquality_NullComparison()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.That(q1.Equals(null), Is.False);
        }

        [Test]
        public void TestEquality_CentimeterToInch_Equivalent()
        {
            var cm = new QuantityLength(1.0, LengthUnit.Centimeter);
            var inch = new QuantityLength(0.393701, LengthUnit.Inch);

            Assert.That(cm.Equals(inch), Is.True);
        }

        [Test]
        public void TestEquality_CentimeterToFeet_NotEquivalent()
        {
            var cm = new QuantityLength(1.0, LengthUnit.Centimeter);
            var feet = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.That(cm.Equals(feet), Is.False);
        }

        [Test]
        public void TestEquality_MultiUnit_TransitiveProperty()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            var feet = new QuantityLength(3.0, LengthUnit.Feet);
            var inches = new QuantityLength(36.0, LengthUnit.Inch);

            Assert.That(yard.Equals(feet), Is.True);
            Assert.That(feet.Equals(inches), Is.True);
            Assert.That(yard.Equals(inches), Is.True);
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

