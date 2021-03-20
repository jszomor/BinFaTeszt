using System;

namespace BinFaTeszt
{
  public static class Fibonacci
  {
    // 1 1 2 3 5 8...

    public static int Get(int n)
    {
      if (n < 1) throw new ArgumentException("n must be 1 or higher", nameof(n));
      if (n < 3) return 1;

      var (a, b) = (1, 1);
      n = n - 2;
      while (n > 0)
      {
        (a, b) = (b, a + b);
        n--;
      }

      return b;
    }

    public static int Get2(int n)
    {
      if (n < 1) throw new ArgumentException("n must be 1 or higher", nameof(n));
      if (n < 3) return 1;

      //var (a, b) = (1, 1);
      int a = 1;
      int b = 1;

      n = n - 2;
      while (n > 0)
      {
        (a, b) = (b, a + b);
        //b = a + b;
        //a = b;
        n--;
      }

      return b;
    }

    public static void voidFibonacci_Iterative(int len)
    {
      int a = 0, b = 1, c = 0;
      Console.Write("{0} {1}", a, b);
      for (int i = 2 ; i < len; i++)
      {
        c = a + b;
        Console.Write(" {0}", c);
        a = b;
        b = c;
      }
    }

    public static int fibonacciRec(int n)
    {
      if (n < 2)
      {
        return n;
      }
      else
      {
        return fibonacciRec(n - 1) + fibonacciRec(n - 2);
      }
    }

    public static int fibonacciNext(int n)
    {
      //if (n < 3) return 1;

      int F = 0;
      int prev = 1;
      int next;
      for (int i = 0; i < n; ++i)
      {
        next = F + prev;
        prev = F;
        F = next;
      }
      return F;
    }

    public static int Fibx(int n)
    {
      if (n < 0)  { throw new ArgumentOutOfRangeException("Can not have negative number"); }
      if (n == 0) { return 0; }
      if (n < 3)  { return 1; }

      //var (a, b, c) = (1, 1, 0); //tuples
      int a = 1;
      int b = 1;
      int c = 0;

      while (n > 2)
      {
        //(a, b) = (b, a + b); // tuples
        c = a + b;
        a = b;
        b = c;
        n--;
      }
      return c;
    }
  }
}
