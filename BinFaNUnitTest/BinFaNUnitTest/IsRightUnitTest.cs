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

    public void Setup2()
    {

    }

    [Test]
    public void IsRight()
    {

      string item = "kutya";
      BinFa<string> printFa = new BinFa<string>(item);
      string[] array = new string[] { "almafa", "körtefa", "diofa", "szilvafa", "fügefa", "meggyfa" };

      foreach (var i in array)
      {
        printFa.Add2(i);

        if (printFa == null)
        {
          return;
        }

        if (printFa.Root.Left != null)
        {
          Assert.IsFalse(false);
        }

        if (printFa.Root.Right != null)
        {
          Assert.IsTrue(true);
        }
      }
      
    }
  }
}