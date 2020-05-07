using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinFaTeszt
{
  class Program
  {
    static void Main(string[] args)
    {
      string item = "kutya";
      BinFa<string> binFa = new BinFa<string>(item);

      binFa.Insert(true, "almafa");
      binFa.Insert(false, "körtefa");
      binFa.Insert(false, "diofa");
      binFa.Insert(true, "szilvafa");
      binFa.Insert(false, "fügefa");

      binFa.Print();
      Console.ReadKey();
    }
  }
}
