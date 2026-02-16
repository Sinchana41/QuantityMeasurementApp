using QuantityMeasurementApp.Models;

namespace QuantityMeasurementAppTest
{
    public class QuantityLengthTests
    {

        private const double EPSILON = 0.0001; //small number used when comparing floating-point numbers
   
        // SAME UNIT ADDITION
        [Test]
        public void TestAddition_SameUnit_FeetPlusFeet()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(2.0, LengthUnit.Feet);

            var result = a.Add(b);

            Assert.That(result.Value, Is.EqualTo(3.0));
            Assert.That(result.Unit, Is.EqualTo(LengthUnit.Feet));
        }

        [Test]
        public void TestAddition_SameUnit_InchPlusInch()
        {
            var a = new QuantityLength(6.0, LengthUnit.Inch);
            var b = new QuantityLength(6.0, LengthUnit.Inch);

            var result = a.Add(b);

            Assert.That(result.Value, Is.EqualTo(12.0));
        }

        // CROSS UNIT ADDITION
        [Test]
        public void TestAddition_FeetPlusInches()
        {
            var feet = new QuantityLength(1.0, LengthUnit.Feet);
            var inches = new QuantityLength(12.0, LengthUnit.Inch);

            var result = feet.Add(inches);

            Assert.That(result.Value, Is.EqualTo(2.0).Within(EPSILON));
            Assert.That(result.Unit, Is.EqualTo(LengthUnit.Feet));
        }

        [Test]
        public void TestAddition_InchesPlusFeet()
        {
            var inches = new QuantityLength(12.0, LengthUnit.Inch);
            var feet = new QuantityLength(1.0, LengthUnit.Feet);

            var result = inches.Add(feet);

            Assert.That(result.Value, Is.EqualTo(24.0).Within(EPSILON));
            Assert.That(result.Unit, Is.EqualTo(LengthUnit.Inch));
        }

        [Test]
        public void TestAddition_YardPlusFeet()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            var feet = new QuantityLength(3.0, LengthUnit.Feet);

            var result = yard.Add(feet);

            Assert.That(result.Value, Is.EqualTo(2.0).Within(EPSILON));
            Assert.That(result.Unit, Is.EqualTo(LengthUnit.Yard));
        }

        [Test]
        public void TestAddition_CentimeterPlusInch()
        {
            var cm = new QuantityLength(2.54, LengthUnit.Centimeter);
            var inch = new QuantityLength(1.0, LengthUnit.Inch);

            var result = cm.Add(inch);

            Assert.That(result.Value, Is.EqualTo(5.08).Within(0.01));
            Assert.That(result.Unit, Is.EqualTo(LengthUnit.Centimeter));
        }

        // COMMUTATIVITY
        [Test]
        public void TestAddition_Commutative()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            var result1 = a.Add(b);
            var result2 = b.Add(a);

            double r1Inches = result1.Value * result1.Unit.ToInchesFactor();
            double r2Inches = result2.Value * result2.Unit.ToInchesFactor();

            Assert.That(r1Inches, Is.EqualTo(r2Inches).Within(EPSILON));
        }

        // ZERO
        [Test]
        public void TestAddition_WithZero()
        {
            var a = new QuantityLength(5.0, LengthUnit.Feet);
            var zero = new QuantityLength(0.0, LengthUnit.Inch);

            var result = a.Add(zero);

            Assert.That(result.Value, Is.EqualTo(5.0));
        }

        // NEGATIVE VALUES
        [Test]
        public void TestAddition_NegativeValues()
        {
            var a = new QuantityLength(5.0, LengthUnit.Feet);
            var b = new QuantityLength(-2.0, LengthUnit.Feet);

            var result = a.Add(b);

            Assert.That(result.Value, Is.EqualTo(3.0));
        }

        // NULL VALIDATION
        [Test]
        public void TestAddition_NullSecondOperand_Throws()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.Throws<ArgumentNullException>(() => a.Add(null));
        }

        // LARGE VALUES
        [Test]
        public void TestAddition_LargeValues()
        {
            var a = new QuantityLength(1e6, LengthUnit.Feet);
            var b = new QuantityLength(1e6, LengthUnit.Feet);

            var result = a.Add(b);

            Assert.That(result.Value, Is.EqualTo(2e6));
        }

        // SMALL VALUES
        [Test]
        public void TestAddition_SmallValues()
        {
            var a = new QuantityLength(0.001, LengthUnit.Feet);
            var b = new QuantityLength(0.002, LengthUnit.Feet);

            var result = a.Add(b);

            Assert.That(result.Value, Is.EqualTo(0.003).Within(EPSILON));
        }
    }
}

