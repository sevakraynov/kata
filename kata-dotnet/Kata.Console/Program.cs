using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

new Solution().FindShortestSubArray(new int[] { 1, 2, 2, 3, 1 });

public static class ConsoleEx
{
    public static void Debugify<T>(IEnumerable<T> list, string glue = "\n")
        => Console.WriteLine(string.Join(glue, list.Select(x => x?.ToString())));
}


// Console.WriteLine(new Solution().ReverseString(2.0, 2));


public class Node
{
    public int Value { get; set; }

    public int Left { get; set; }

    public int Right { get; set; }
}


public class Solution
{
    public void ReverseString(char[] s)
    {
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            (s[left], s[right]) = (s[right], s[left]);

            left++;
            right--;
        }
    }

    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 0)
        {
            return string.Empty;
        }

        var prefix = strs[0];
        for (var i = 1; i < strs.Length; i++)
        {
            while (strs[i].IndexOf(prefix, StringComparison.Ordinal) != 0)
            {
                prefix = prefix[..^1];

                if (string.IsNullOrEmpty(prefix))
                {
                    return string.Empty;
                }
            }
        }

        return prefix;
    }

    public string ReverseWords(string s)
    {
        var sb = new StringBuilder();
        var i = s.Length - 1;
        while (i >= 0)
        {
            if (s[i] == ' ')
            {
                i--;
                continue;
            }

            var j = i;
            while (i >= 0 && s[i] != ' ')
            {
                i--;
            }

            if (sb.Length > 0)
            {
                sb.Append(' ');
            }

            sb.Append(s[(i + 1)..(j + 1)]);
        }

        return sb.ToString();
    }

    public int LengthOfLongestSubstring(string s)
    {
        var ans = 0;
        var l = s.Length;
        var set = new HashSet<char>();
        for (int i = 0, j = 0; j < l; j++)
        {
            while (set.Contains(s[j]))
            {
                set.Remove(s[i]);
                i++;
            }

            set.Add(s[j]);
            ans = Math.Max(ans, j - i + 1);
        }

        return ans;
    }

    public bool IsValid(string s)
    {
        var stack = new Stack<char>();

        foreach (var symbol in s) { }

        return stack.Count == 0;
    }

    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var chars = s.GroupBy(q => q).ToDictionary(q => q.Key, q => q.Count());

        foreach (var symbol in t)
        {
            if (!chars.ContainsKey(symbol))
            {
                return false;
            }

            chars[symbol]--;
            if (chars[symbol] == 0)
            {
                chars.Remove(symbol);
            }
        }

        return chars.Count == 0;
    }

    public IList<string> GenerateParenthesis(int n)
    {
        var list = new List<string>();

        Generate(string.Empty, 0, 0);

        return list;

        void Generate(
            string current,
            int opened,
            int closing)
        {
            if (current.Length == 2 * n)
            {
                list.Add(current);
                return;
            }

            if (opened < n)
            {
                Generate(current + "(", opened + 1, closing);
            }

            if (closing < opened)
            {
                Generate(current + ")", opened, closing + 1);
            }
        }
    }

    public IList<string> LetterCombinations(string digits)
    {
        var result = new List<string>();
        if (string.IsNullOrEmpty(digits))
        {
            return result;
        }

        var chars = new Dictionary<int, string>
        {
            { 2, "abc" },
            { 3, "def" },
            { 4, "ghi" },
            { 5, "jkl" },
            { 6, "mno" },
            { 7, "pqrs" },
            { 8, "tuv" },
            { 9, "wxyz" }
        };

        var strings = digits.Select(d => d - '0').Where(q => q > 1).Select(key => chars[key]).ToArray();

        Generate("", strings);

        return result;

        void Generate(string str, string[] last)
        {
            if (last.Length == 1)
            {
                result.AddRange(last[0].Select(letter => str + letter));
                return;
            }

            foreach (var letter in last[0])
            {
                Generate(str + letter, last[1..]);
            }
        }
    }

    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        var numsLength = nums.Length;

        for (var setSize = 0; setSize <= numsLength; setSize++)
        {
            Generate(0, new List<int>(), setSize);
        }

        return result;

        void Generate(int first, List<int> curr, int size)
        {
            if (curr.Count == size)
            {
                result.Add(new List<int>(curr));
                return;
            }

            for (var i = first; i < numsLength; i++)
            {
                curr.Add(nums[i]);
                Generate(i + 1, curr, size);
                curr.RemoveAt(curr.Count - 1);
            }
        }
    }

    public void SortColors(int[] nums)
    {
        int zeros = 0, ones = 0;
        foreach (var num in nums)
        {
            switch (num)
            {
                case 1:
                    ones++;
                    continue;

                case 0:
                    zeros++;
                    continue;
            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (zeros > 0)
            {
                nums[i] = 0;
                zeros--;
                continue;
            }

            if (ones > 0)
            {
                nums[i] = 1;
                ones--;
                continue;
            }

            nums[i] = 2;
        }
    }

    public int[] TwoSum(int[] nums, int target)
    {
        var d = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var curr = target - nums[i];
            if (d.TryGetValue(curr, out var index))
            {
                return new[] { index, i };
            }

            d[nums[i]] = i;
        }

        return Array.Empty<int>();
    }

    public int LengthOfLastWord(string s)
    {
        var length = 0;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ' ')
            {
                if (length > 0)
                {
                    return length;
                }

                continue;
            }

            length++;
        }

        return length;
    }

    public int[] PlusOne(int[] digits)
    {
        for (var i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] == 9)
            {
                digits[i] = 0;
            }
            else
            {
                digits[i]++;
                return digits;
            }
        }

        var result = new int[digits.Length + 1];
        Array.Copy(digits, 0, result, 1, digits.Length);
        result[0] = 1;

        return result;
    }

    public bool CanJump(int[] nums)
    {
        var r = 0;
        for (var i = 0; i < nums.Length && i <= r; i++)
        {
            r = Math.Max(r, nums[i] + i);

            if (r >= nums.Length - 1)
            {
                return true;
            }
        }

        return false;
    }

    public void MoveZeroes(int[] nums)
    {
        var current = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[current] = nums[i];
                current++;
            }
        }

        for (var i = current; i < nums.Length; i++)
        {
            nums[i] = 0;
        }
    }

    public int[] AsteroidCollision(int[] asteroids)
    {
        var stack = new Stack<int>();
        foreach (var asteroid in asteroids)
        {
            if (asteroid > 0)
            {
                stack.Push(asteroid);
                continue;
            }

            while (stack.Count > 0)
            {
                var peek = stack.Peek();
                if (peek > 0 && peek < Math.Abs(asteroid))
                {
                    stack.Pop();
                    continue;
                }

                break;
            }

            if (stack.Count == 0 || stack.TryPeek(out var p) && p < 0)
            {
                stack.Push(asteroid);
            }
            else if (Math.Abs(stack.Peek()) == Math.Abs(asteroid))
            {
                stack.Pop();
            }
        }

        return stack.Reverse().ToArray();
    }

    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var max = candies.Max();
        return candies.Select(q => q + extraCandies >= max).ToList();
    }

    public double Average(int[] salary)
    {
        var max = salary.Max();
        var min = salary.Min();

        return salary.Where(q => q > min && q < max).Average();
    }

    public int MaxProfit_1(int[] prices)
    {
        if (prices.Length == 0)
        {
            return 0;
        }

        var maxProfit = 0;
        var buyAt = prices[0];

        for (var i = 1; i < prices.Length; i++)
        {
            maxProfit = Math.Max(maxProfit, prices[i] - buyAt);
            if (prices[i] < buyAt)
            {
                buyAt = prices[i];
            }
        }

        return maxProfit;
    }

    public int MaxProfit(int[] prices)
    {
        if (prices.Length == 0)
        {
            return 0;
        }

        var maxProfit = 0;

        for (var i = 0; i < prices.Length - 1; i++)
        {
            if (prices[i + 1] > prices[i])
            {
                maxProfit += prices[i + 1] - prices[i];
            }
        }

        return maxProfit;
    }

    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        var b = new bool[nums.Length];

        foreach (var num in nums)
        {
            if (!b[num - 1])
            {
                b[num - 1] = true;
            }
        }

        var l = new List<int>();

        for (var i = 0; i < b.Length; i++)
        {
            if (!b[i])
            {
                l.Add(i + 1);
            }
        }

        return l;
    }

    public IList<IList<int>> Generate(int numRows)
    {
        var result = new List<IList<int>>
        {
            new List<int> { 1 },
            new List<int>
            {
                1,
                1
            }
        };

        if (numRows == 1)
        {
            return new List<IList<int>> { result[0] };
        }

        if (numRows == 2)
        {
            return result;
        }

        for (var i = 3; i < numRows; i++)
        {
            var prev = result[i - 2];
            var temp = new int[i];
            temp[0] = 1;
            temp[i - 1] = 1;

            for (var j = 1; j < i - 1; j++)
            {
                temp[j] = prev[j - 1] + prev[j];
            }

            result.Add(temp);
        }

        return result;
    }

    public IList<int> GetRow(int rowIndex)
    {
        var current = new[] { 1 };

        if (rowIndex == 0)
        {
            return current;
        }

        for (var i = 1; i <= rowIndex; i++)
        {
            var next = new int[i + 1];
            next[0] = 1;
            next[i] = 1;

            for (var j = 1; j < next.Length - 1; j++)
            {
                next[j] = current[j - 1] + current[j];
            }

            current = next;
        }

        return current;
    }

    public IList<int> SequentialDigits(int low, int high)
    {
        var digits = "123456789";
        var lowCount = CountDigits(low);
        var highCount = CountDigits(high);
        var result = new List<int>();

        for (var i = lowCount; i < highCount + 1; i++)
        {
            for (var j = 0; j <= digits.Length - i; j++)
            {
                var value = int.Parse(digits[j..(j + i)]);
                if (value >= low && value <= high)
                {
                    result.Add(value);
                }
            }
        }

        return result;

        int CountDigits(int number)
        {
            var count = 0;
            while (number > 0)
            {
                count++;
                number /= 10;
            }

            return count;
        }
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        result[0] = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            result[i] = nums[i - 1] * result[i - 1];
        }

        var right = 1;

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            result[i] *= right;
            right *= nums[i];
        }

        return result;
    }

    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        var position = -1;
        var current = 0;
        var total = 0;

        for (var i = 0; i < gas.Length; i++)
        {
            var diff = gas[i] - cost[i];
            current += diff;
            total += diff;

            if (current < 0)
            {
                current = 0;
                position = i;
            }
        }

        return total >= 0 ? position + 1 : -1;
    }

    public void Rotate(int[] nums, int k)
    {
        var l = k % nums.Length;
        Reverse(0, nums.Length - 1);
        Reverse(0, l - 1);
        Reverse(l, nums.Length - 1);

        void Reverse(int left, int right)
        {
            while (left <= right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
        }
    }

    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        var length = tops.Length;
        var founded = false;
        var max = tops.Length + 1;
        var answer = max;

        for (var v = 1; v < 7; v++)
        {
            var findRotationsCount = FindRotationsCount(v);
            if (findRotationsCount == -1)
            {
                continue;
            }

            answer = Math.Min(answer, findRotationsCount);
            founded = true;
        }

        return founded ? answer : -1;

        int FindRotationsCount(int value)
        {
            var topRotations = 0;
            var bottomRotations = 0;

            for (var i = 0; i < length; i++)
            {
                if (tops[i] != value && bottoms[i] != value)
                {
                    return -1;
                }

                if (tops[i] != value)
                {
                    topRotations++;
                }
                else if (bottoms[i] != value)
                {
                    bottomRotations++;
                }
            }

            return Math.Min(topRotations, bottomRotations);
        }
    }

    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1)
        {
            return 0;
        }

        var count = 0;
        var left = 0;
        var prod = 1;

        for (var right = 0; right < nums.Length; right++)
        {
            prod *= nums[right];
            while (prod >= k)
            {
                prod /= nums[left];
                left++;
            }

            count += right - left + 1;
        }

        return count;
    }

    public bool CanReach(int[] arr, int start)
    {
        var n = arr.Length;
        var visitedPositions = new bool[n];
        var queue = new Queue<int>();

        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var currentPosition = queue.Dequeue();
            visitedPositions[currentPosition] = true;

            if (arr[currentPosition] == 0)
            {
                return true;
            }

            var leftJumpPosition = currentPosition - arr[currentPosition];
            var rightJumpPosition = currentPosition + arr[currentPosition];

            if (leftJumpPosition >= 0 && leftJumpPosition < n)
            {
                if (!visitedPositions[leftJumpPosition])
                {
                    queue.Enqueue(leftJumpPosition);
                }
            }

            if (rightJumpPosition >= 0 && rightJumpPosition < n)
            {
                if (!visitedPositions[rightJumpPosition])
                {
                    queue.Enqueue(rightJumpPosition);
                }
            }
        }

        return false;
    }

    public int FindPairs(int[] nums, int k)
    {
        if (nums.Length == 0 || k < 0)
        {
            return 0;
        }

        var dictionary = nums.GroupBy(q => q).ToDictionary(q => q.Key, q => q.Count());

        return k == 0 ? dictionary.Count(q => q.Value >= 2) : dictionary.Count(q => dictionary.ContainsKey(q.Key + k));
    }

    public int FindShortestSubArray(int[] nums)
    {
        var counters = nums.GroupBy(q => q).ToDictionary(q => q.Key, q => q.Count());
        var degree = counters.Values.Max();
        var left = new Dictionary<int, int>();
        var right = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var current = nums[i];
            if (!left.ContainsKey(current))
            {
                left[current] = i;
            }

            right[current] = i;
        }

        var answer = nums.Length + 1;
        foreach ((var i, var counter) in counters)
        {
            if (counter == degree)
            {
                answer = Math.Min(answer, right[i] - left[i] + 1);
            }
        }

        return answer;
    }

    public int MajorityElement(int[] nums)
    {
        var counter = 0;
        var major = 0;

        foreach (var num in nums)
        {
            if (counter == 0)
            {
                major = num;
                counter = 1;
                continue;
            }

            if (major == num)
            {
                counter++;
            }
            else
            {
                counter--;
            }
        }

        return major;
    }

    public int Rob(int[] nums)
    {
        return nums.Length == 1 ? nums[0] : Math.Max(RobRange(0, nums.Length - 1), RobRange(1, nums.Length));

        int RobRange(int start, int finish)
        {
            var prev1 = 0;
            var prev2 = 0;

            for (var index = start; index < finish; index++)
            {
                var robNext = Math.Max(prev1, prev2 + nums[index]);
                prev2 = prev1;
                prev1 = robNext;
            }

            return Math.Max(prev1, prev2);
        }
    }

    public int MaxProduct(int[] nums)
    {
        var min = 1;
        var max = 1;
        var result = nums[0];

        foreach (var num in nums)
        {
            var tmp = max * num;
            max = Math.Max(num, Math.Max(tmp, min * num));
            min = Math.Min(num, Math.Min(tmp, min * num));
            result = Math.Max(result, max);
        }

        return result;
    }
}
