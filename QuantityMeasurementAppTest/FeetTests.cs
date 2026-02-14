using NUnit.Framework;
using QuantityMeasurementApp.Models;
namespace QuantityMeasurementAppTest
{
    public class FeetTests
    {
        [Test]
        public void TestEquality_SameValue()
        {
            var f1 = new Feet(1.0);
            var f2 = new Feet(1.0);

            Assert.That(f1.Equals(f2), Is.True);
        }

        [Test]
        public void TestEquality_DifferentValue()
        {
            var f1 = new Feet(1.0);
            var f2 = new Feet(2.0);

            Assert.That(f1.Equals(f2), Is.False);
        }

        [Test]
        public void TestEquality_NullComparison()
        {
            var f1 = new Feet(1.0);

            Assert.That(f1.Equals(null), Is.False);
        }

        [Test]
        public void TestEquality_SameReference()
        {
            var f1 = new Feet(1.0);

            Assert.That(f1.Equals(f1), Is.True);
        }
    }
}