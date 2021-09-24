namespace Kata.Tasks.CountOfDivisors
{
    /// <summary>
    /// Класс для решения задачи Count the divisors of a number
    /// </summary>
    /// <remarks>
    /// 
    /// <see cref="https://www.codewars.com/kata/542c0f198e077084c0000c2e">TASK</see>
    /// Count the number of divisors of a positive integer n.
    /// Random tests go up to n = 500000.
    /// 
    /// EXAMPLE:
    /// Kata.Divisors(4)  -> 3 -- 1, 2, 4
    /// Kata.Divisors(5)  -> 2 -- 1, 5
    /// Kata.Divisors(12) -> 6 -- 1, 2, 3, 4, 6, 12
    /// Kata.Divisors(30) -> 8 -- 1, 2, 3, 5, 6, 10, 15, 30
    /// 
    /// </remarks>
    public static class CountOfDivisors
    {
        public static int Divisors(int n)
        {
            int count = 0;
            for (int i = 1; i < n + 1; i++)
            {
                if(n % i == 0) count++;
            }

            return count;
        }
    }
}