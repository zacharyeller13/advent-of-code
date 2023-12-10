using System.Numerics;

namespace AdventOfCode.Lib;

public static class MathExtensions
{
    // I tried my own implementation of GCD, but for some reason I ended up getting a result of 1
    // where I should have 277?  Maybe something with ints vs uints vs longs vs ulongs?
    public static BigInteger GCD(params BigInteger[] numbers)
    {
        return numbers.Aggregate(BigInteger.GreatestCommonDivisor);
    }

    public static BigInteger LCM(params BigInteger[] numbers)
    {
        return numbers.Aggregate((x, y) => x * y / GCD(x, y));
    }
}