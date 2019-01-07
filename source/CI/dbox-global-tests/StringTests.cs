using dbox_global.Utils;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanConvertString_ToDateTime()
        {
            var dt = "2020 01 01".ToDateTime("yyyy MM dd");

            Assert.AreEqual(1, dt.Day);
            Assert.AreEqual(1, dt.Month);
            Assert.AreEqual(2020, dt.Year);
        }
    }
}