namespace AdventOfCode.Lib;

public interface ISolution<T>
{
    public T SolvePart1();
    public T SolvePart2();
    public void PrintLines();
}