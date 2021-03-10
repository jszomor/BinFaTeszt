using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* ❌ Nem-angol identifiers in kód are strictly verboten. Hunglish code is subject of nevetség. */
namespace BinFaTeszt
{
  public class Node<T> where T : IComparable<T>
  {
    // ❌ Miért public és miért nem readonly?
    // Túl könnyő hibás állapotra hozni azzal, ha megváltoztatod kívülről.
    // Vonatkozó OOP alapelv: encapsulation
    public T Core;
    public Node<T> Left;
    public Node<T> Right;

    public Node(T item)
    {
      Core = item;
      /*
       * ❌ Felesleges. Minden field alapból default-ra van inicializálva.
       * A konstruktor meghívása előtt a runtime kitölti 0 bytokkal a memóriaterületet.
       *
       * Feladat: mi lehet az alábbi típusok default értéke?
       * bool
       * string
       * int
       * DateTime
       * Guid
       * long?
       */
      Left = null; 
      Right = null;
    }
  }

  // ❌ Igazából felesleges class, a Node önmagában jó lenne bináris fának.
  public class BinFa<T> where T : IComparable<T>
  {
    public Node<T> Root; // private readonly
    public BinFa(Node<T> root) // OOP: Polimorphism ✅
    {
      Root = root;
    }
    public BinFa(T root) // OOP: Polimorphism ✅
    {
      Node<T> e;
      e = new Node<T>(root);
      Root = e;
    }

    /**
     * ❌ Értelmetlen metódus.
     * Minden híváskor létrehoz egy új fát, amit a metódus nevéből nem lehet kitalálni,
     * és nincs is értelme a fa funkciója szempontjából.
     */
    public BinFa<T> Next(bool isRight)
    {
      BinFa<T> fa;
      if(isRight)
      {
        fa = new BinFa<T>(Root.Right);
      }
      else
        fa = new BinFa<T>(Root.Left);

      return fa;
    }

    /*
     * ❌ hibásan implementált metódus, nem azt csinálja, amit a neve alapján kéne.
     */
    public void Insert(bool isRight, T item)
    {
      BinFa<T> insertFa; // Nem használt változó.
      Node<T> p = new Node<T>(item);
      if(isRight)
      {
        p.Right = Root.Right;
        p.Left = null;
        Root.Right = p;
      }
      else
      {
        p.Right = null;
        p.Left = Root.Left;
        Root.Left = p;
      }
      
    }

    public void Print()
    {
      BinFa<T> printFa = this;
      BinFa<T> otherFa;

      // Mindig false. .NET-ben nem tudsz null-on metódust hívni, kivéve ha extension method.
      if(printFa == null)
      {
        return;
      }      

      Console.WriteLine(Root.Core);
      otherFa = printFa;
      if (printFa.Root.Left != null)
      {
        printFa = printFa.Next(false);
        printFa.Print();
      }
      printFa = otherFa;
      if (printFa.Root.Right != null)
      {
        printFa = printFa.Next(true);
        printFa.Print();
      }
    }

    // ❌ Dead code, lásd lejjebb.
    public void Add(T item)
    {
      BinFa<T> addFa = this;
      BinFa<T> newFa = new BinFa<T>(item);
      
      // ❌ Adj értelmes nevet a változóknak. Sokkal könnyebben érthető a kód.
      // Egyszer kell begépelned, utána az IDE felkínálja. Amennyi időt spórolsz a gépelésen,
      // annak a többszörösébe kerül megérteni a kódot. Ez az egyik leggyakoribb kezdő hiba.
      int ii = item.CompareTo(addFa.Root.Core);

      //other = addFa;

      Console.WriteLine(addFa.Root.Core);

      if (ii < 0)
      {
        if (addFa.Next(false) == null)
        {
          newFa.Insert(false, item);
          addFa.Add(item);
        }
        else
        {
          addFa = addFa.Next(false);
        }
      }
      else if (ii > 0)
      {
        if (addFa.Next(true) == null)
        {
          newFa.Insert(true, item);
          addFa.Add(item);
        }
        else
        {
          addFa = addFa.Next(false);
        }
      }
    }
    
    
    /*
     * Ilyenkor a másik metódust inkább kommenteld ki, és legyen ez az Add.
     * (kijelöl, Ctrl+K, Ctrl+C, visszacsinálni Ctrl+K, Ctrl+U)
     * Az ehhez hasonló szemetelés idővel értelmezhetlenné teszi a kódot.
     *
     * Az algoritmus hibás, ami azonnal kiütközne, ha lennének hozzá tesztek.
     * A teszteletlen kód a másik gyakori hiba. Xunit ajánlott manapság.
     * https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test
     */
    
    public void Add2(T item)
    {
      BinFa<T> insertFa = this;
      Node<T> p = new Node<T>(item);
      int ii = item.CompareTo(insertFa.Root.Core);
      if (ii < 0)
      {
        p.Right = Root.Right;
        p.Left = null;
        Root.Right = p;
      }
      else
      {
        p.Right = null;
        p.Left = Root.Left;
        Root.Left = p;
      }

    }
  }
}
