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

      //binFa.Insert(true, "almafa");
      //binFa.Insert(false, "körtefa");
      //binFa.Insert(false, "diofa");
      //binFa.Insert(true, "szilvafa");
      //binFa.Insert(false, "fügefa");
      binFa.Add2("almafa");
      binFa.Add2("körtefa");
      binFa.Add2("diofa");
      binFa.Add2("szilvafa");
      binFa.Add2("fügefa");
      binFa.Add2("meggyfa");
      binFa.Print();
      Console.ReadKey();
    }
  }
}
