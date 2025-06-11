using NUnit.Framework;
using Z1;

namespace Z1.Tests
{
    [TestFixture]
    public class CzłonekZespołuTests
    {
        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_WiekRowny()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "", 12);

            Assert.AreEqual(0, a.CompareTo(b));
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_WiekWiekszy()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "", 10);

            Assert.Greater(a.CompareTo(b),0);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_WiekMniejszy()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "", 14);

            Assert.Less(a.CompareTo(b), 0);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_RoznyWiek()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "", 14);

            Assert.AreNotEqual(0, a.CompareTo(b));
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_RowneNazwiska()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "AAA", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "AAA", 14);
            CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer comparer = new CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer();

            Assert.AreEqual(0, comparer.Compare(a, b));
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_PierwszeNazwiskoMniejsze()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "AA", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "AAA", 14);
            CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer comparer = new CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer();

            Assert.Less(comparer.Compare(a, b), 0);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_DrugieNazwiskoMniejsze()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "AAAAA", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "AAA", 14);
            CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer comparer = new CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer();

            Assert.Greater(comparer.Compare(a, b), 0);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_RozneNazwiska()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "AAAAA", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "ABDFS", 14);
            CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer comparer = new CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer();

            Assert.AreNotEqual(0, comparer.Compare(a, b));
        }

        [Test]
        public void TestToString_PoprawnyFormat()
        {
            CzłonekZespołu a = new CzłonekZespołu("DD", "AA", 12);

            Assert.AreEqual("Imie: DD\tNazwisko: AA\t\tWiek: 12", a.ToString());
        }

        [Test]
        public void TestTworzeniaObiektuCzlonkaZespolu_ZPoprawnymiDanymi()
        {
            CzłonekZespołu a = new CzłonekZespołu("asd", "asd", 12);
            Assert.NotNull(a);
        }
        
        [Test]
        public void TestTworzeniaObiektuCzlonkaZespolu_ZNiepoprawnymiDanymi()
        {
            Assert.Throws<ArgumentException>(() => new CzłonekZespołu(null, "sd",12));
            Assert.Throws<ArgumentException>(() => new CzłonekZespołu("aasd", null, 12));
            Assert.Throws<ArgumentException>(() => new CzłonekZespołu("asd", "asd", -1));
        }
    }
}
