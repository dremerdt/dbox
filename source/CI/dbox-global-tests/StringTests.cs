using dbox_global.Extensions;
using dbox_global.Utils;
using NUnit.Framework;

namespace dbox_global_tests
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

        [Test]
        public void Can_RemoveDiacritics()
        {
            const string word = "național";

            Assert.AreEqual("national", word.RemoveDiacritics());
        }
    }
}