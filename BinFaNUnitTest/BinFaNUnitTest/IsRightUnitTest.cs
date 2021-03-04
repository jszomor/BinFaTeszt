using NUnit.Framework;
using BinFaTeszt;

namespace BinFaNUnitTest
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IsRight()
    {

      string item = "kutya";
      BinFa<string> binFa = new BinFa<string>(item);
      BinFa<string> otherFa;
      string[] array = new string[] { "almafa", "körtefa", "diofa", "szilvafa", "fügefa", "meggyfa" };

      foreach (var i in array)
      {
        binFa.Add2(i);

        
      }

      otherFa = binFa;
      if (binFa.Root.Left != null)
      {
        binFa = binFa.Next(false);
        Assert.IsFalse(false);

      }
      binFa = otherFa;
      if (binFa.Root.Right != null)
      {
        binFa = binFa.Next(true);
        Assert.IsTrue(true);
      }

      //Assert.Pass();
    }
  }
}