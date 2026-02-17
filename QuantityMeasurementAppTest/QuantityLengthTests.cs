using QuantityMeasurementApp.Models;

namespace QuantityMeasurementAppTest
{
    public class QuantityLengthTests
    {

        private const double EPSILON = 0.001;

        [Test]
        public void TestAddition_ExplicitTargetUnit_Feet()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            var result = a.Add(b, LengthUnit.Feet);

            Assert.That(result.Value, Is.EqualTo(2.0).Within(EPSILON));
            Assert.That(result.Unit, Is.EqualTo(LengthUnit.Feet));
        }

        [Test]
        public void TestAddition_ExplicitTargetUnit_Inches()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            var result = a.Add(b, LengthUnit.Inch);

            Assert.That(result.Value, Is.EqualTo(24.0).Within(EPSILON));
            Assert.That(result.Unit, Is.EqualTo(LengthUnit.Inch));
        }

        [Test]
        public void TestAddition_ExplicitTargetUnit_Yards()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            var result = a.Add(b, LengthUnit.Yard);

            Assert.That(result.Value, Is.EqualTo(0.667).Within(0.01));
            Assert.That(result.Unit, Is.EqualTo(LengthUnit.Yard));
        }

        [Test]
        public void TestAddition_ExplicitTargetUnit_Centimeters()
        {
            var a = new QuantityLength(1.0, LengthUnit.Inch);
            var b = new QuantityLength(1.0, LengthUnit.Inch);

            var result = a.Add(b, LengthUnit.Centimeter);

            Assert.That(result.Value, Is.EqualTo(5.08).Within(0.01));
        }

        [Test]
        public void TestAddition_ExplicitTargetUnit_Commutativity()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            var result1 = a.Add(b, LengthUnit.Yard);
            var result2 = b.Add(a, LengthUnit.Yard);

            Assert.That(result1.Value, Is.EqualTo(result2.Value).Within(EPSILON));
        }

        [Test]
        public void TestAddition_ExplicitTargetUnit_WithZero()
        {
            var a = new QuantityLength(5.0, LengthUnit.Feet);
            var zero = new QuantityLength(0.0, LengthUnit.Inch);

            var result = a.Add(zero, LengthUnit.Yard);

            Assert.That(result.Value, Is.EqualTo(1.667).Within(0.01));
        }

        [Test]
        public void TestAddition_ExplicitTargetUnit_NegativeValues()
        {
            var a = new QuantityLength(5.0, LengthUnit.Feet);
            var b = new QuantityLength(-2.0, LengthUnit.Feet);

            var result = a.Add(b, LengthUnit.Inch);

            Assert.That(result.Value, Is.EqualTo(36.0));
        }

        [Test]
        public void TestAddition_ExplicitTargetUnit_NullTarget_Throws()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.Throws<ArgumentException>(() =>
                a.Add(b, (LengthUnit)999));
        }

        [Test]
        public void TestAddition_ExplicitTargetUnit_LargeScale()
        {
            var a = new QuantityLength(1000.0, LengthUnit.Feet);
            var b = new QuantityLength(500.0, LengthUnit.Feet);

            var result = a.Add(b, LengthUnit.Inch);

            Assert.That(result.Value, Is.EqualTo(18000.0));
        }

        [Test]
        public void TestAddition_ExplicitTargetUnit_SmallToLargeScale()
        {
            var a = new QuantityLength(12.0, LengthUnit.Inch);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            var result = a.Add(b, LengthUnit.Yard);

            Assert.That(result.Value, Is.EqualTo(0.667).Within(0.01));
        }
    }
}

