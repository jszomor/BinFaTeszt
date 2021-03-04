using NUnit.Framework;
using BinFaTeszt;

namespace BinFaNUnitTest
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
      string item = "kutya";
      BinFa<string> binFa = new BinFa<string>(item);

      //binFa.Insert(true, "almafa");
      //binFa.Insert(false, "k�rtefa");
      //binFa.Insert(false, "diofa");
      //binFa.Insert(true, "szilvafa");
      //binFa.Insert(false, "f�gefa");
      binFa.Add2("almafa");
      binFa.Add2("k�rtefa");
      binFa.Add2("diofa");
      binFa.Add2("szilvafa");
      binFa.Add2("f�gefa");
      binFa.Add2("meggyfa");
      IsRight(binFa);
    }

    [Test]
    public void IsRight(BinFa<string> binFa)
    {
      Assert.Pass();
    }
  }
}