using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinFaTeszt
{
  public class Node<T> where T : IComparable<T>
  {
    public T Core;
    public Node<T> Left;
    public Node<T> Right;

    public Node(T item)
    {
      Core = item;
      Left = null;
      Right = null;
    }
  }

  public class BinFa<T> where T : IComparable<T>
  {
    public Node<T> Root;
    public BinFa(Node<T> root)
    {
      Root = root;
    }
    public BinFa(T root)
    {
      Node<T> e;
      e = new Node<T>(root);
      Root = e;
    }

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

    public void Insert(bool isRight, T item)
    {
      BinFa<T> insertFa;
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

    public void Add(T item)
    {
      BinFa<T> addFa = this;
      BinFa<T> other;
      int ii = item.CompareTo(addFa.Root.Core);

      if(ii < 0)
      {
        if(addFa.Next(false))
        addFa.Add(item);
      }
      else if (ii > 0)
      {

      }
    }
  }
}
