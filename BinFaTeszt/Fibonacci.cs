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
    }
}
