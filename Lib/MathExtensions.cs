using System.Numerics;

namespace AdventOfCode.Lib;

public static class MathExtensions
{
    // I tried my own implementation of GCD, but for some reason I ended up getting a result of 1
    // where I should have 277?  Maybe something with ints vs uints vs longs vs ulongs?
    public static ulong GCD(params BigInteger[] numbers)
    {
        return (ulong)numbers.Aggregate(BigInteger.GreatestCommonDivisor);
    }

    public static ulong GCD(params ulong[] numbers)
    {
        return numbers.Aggregate(GCD2);
    }

    private static ulong GCD2(ulong a, ulong b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
    
    public static BigInteger LCM(params BigInteger[] numbers)
    {
        return numbers.Aggregate((x, y) => x * y / GCD(x, y));
    }
    
    public static ulong LCM(params ulong[] numbers)
    {
        return numbers.Aggregate((x, y) => x * y / GCD2(x, y));
    }
}