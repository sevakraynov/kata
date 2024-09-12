#pragma warning disable CS8321
#pragma warning disable CA1854 // Prefer the 'IDictionary.TryGetValue(TKey, out TValue)' method
#pragma warning disable CA1311 // Specify a culture or use an invariant version

using Kata.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#region Helpers

List<int?> ParseTreeNodeStrIntoValueArray(string treeNodeStr)
{
    List<int?> valueArray = []
    ;

    treeNodeStr = treeNodeStr.ToLower();
    var valueListStr = treeNodeStr.Trim(' ', '[', ']');

    if (valueListStr.Length == 0)
    {
        return valueArray;
    }

    var valueStrArray = valueListStr.Split(",").ToArray();
    foreach (var value in valueStrArray)
    {
        var str = value.Trim();
        if (str == "null")
        {
            valueArray.Add(null);
        }
        else
        {
            var number = int.Parse(str);
            valueArray.Add(number);
        }
    }

    return valueArray;
}

TreeNode? BuildTree(IReadOnlyList<int?> array, int i, int n)
{
    TreeNode? root = null;
    if (i >= n || !array[i].HasValue)
    {
        return root;
    }

    root = new TreeNode(array[i]!.Value)
    {
        left = BuildTree(array, 2 * i + 1, n),
        right = BuildTree(array, 2 * i + 2, n)
    };

    return root;
}

TreeNode? BuildTreeFromString(string str)
{
    var list = ParseTreeNodeStrIntoValueArray(str);
    return BuildTree(list, 0, list.Count);
}

static void Debugify<T>(IEnumerable<T> list, string glue = "\n")
    => Console.WriteLine(string.Join(glue, list.Select(x => x?.ToString())));

#endregion

// https://leetcode.com/problems/merge-sorted-array/
void MergeSortedArray(
    int[] nums1,
    int m,
    int[] nums2,
    int n)
{
    var last = m + n - 1;
    var i = m - 1;
    var j = n - 1;

    while (i >= 0 && j >= 0)
    {
        if (nums1[i] > nums2[j])
        {
            nums1[last] = nums1[i];
            i--;
        }
        else
        {
            nums1[last] = nums2[j];
            j--;
        }

        last--;
    }

    while (j >= 0)
    {
        nums1[last] = nums2[j];
        last--;
        j--;
    }
}

// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
int RemoveDuplicates(int[] nums)
{
    var index = 1;
    for (var i = 1; i < nums.Length; i++)
    {
        if (nums[i] == nums[i - 1])
        {
            continue;
        }

        nums[index] = nums[i];
        index++;
    }

    return index;
}

// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
int RemoveDuplicates2(int[] nums)
{
    var index = 1;
    var a = 1;
    for (var i = 1; i < nums.Length; i++)
    {
        if (nums[i] == nums[i - 1])
        {
            switch (a)
            {
                case 1:
                    nums[index] = nums[i];
                    index++;
                    a++;
                    continue;

                case 2:
                    continue;
            }
        }
        else
        {
            nums[index] = nums[i];
            index++;
            a = 1;
        }
    }

    return index;
}

// https://leetcode.com/problems/remove-element/
int RemoveElement(int[] nums, int val)
{
    var index = 0;
    for (var i = 0; i < nums.Length; i++)
    {
        if (nums[i] == val)
        {
            continue;
        }

        nums[index] = nums[i];
        index++;
    }

    return index;
}

// https://leetcode.com/problems/factorial-trailing-zeroes/description/
int TrailingZeroes(int n)
{
    var count = 0;
    while (n > 0)
    {
        n /= 5;
        count += n;
    }

    return count;
}

// https://leetcode.com/problems/powx-n/
double MyPow(double x, int n)
{
    double ans = 1;
    long pow = n;
    if (n < 0)
    {
        pow *= -1;
    }

    while (pow > 0)
    {
        if (pow % 2 == 0)
        {
            x *= x;

            pow /= 2;
        }
        else
        {
            ans *= x;
            pow--;
        }
    }

    return n < 0 ? 1.0 / ans : ans;
}

// https://leetcode.com/problems/reverse-string/
void ReverseString(char[] s)
{
    int left = 0, right = s.Length - 1;

    while (left < right)
    {
        (s[left], s[right]) = (s[right], s[left]);

        left++;
        right--;
    }
}

// https://leetcode.com/problems/longest-common-prefix
string LongestCommonPrefix(string[] strs)
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

// https://leetcode.com/problems/reverse-words-in-a-string/
string ReverseWords(string s)
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

// https://leetcode.com/problems/longest-substring-without-repeating-characters/
int LengthOfLongestSubstring(string s)
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

// https://leetcode.com/problems/valid-anagram/
bool IsAnagram(string s, string t)
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

// https://leetcode.com/problems/generate-parentheses/
IList<string> GenerateParenthesis(int n)
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

// https://leetcode.com/problems/letter-combinations-of-a-phone-number/
IList<string> LetterCombinations(string digits)
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

// https://leetcode.com/problems/subsets/
IList<IList<int>> Subsets(int[] nums)
{
    var result = new List<IList<int>>();
    var numsLength = nums.Length;

    for (var setSize = 0; setSize <= numsLength; setSize++)
    {
        Generate(0, [], setSize);
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

// https://leetcode.com/problems/sort-colors/
void SortColors(int[] nums)
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

// https://leetcode.com/problems/two-sum/
int[] TwoSum(int[] nums, int target)
{
    var d = new Dictionary<int, int>();

    for (var i = 0; i < nums.Length; i++)
    {
        var curr = target - nums[i];
        if (d.TryGetValue(curr, out var index))
        {
            return [index, i];
        }

        d[nums[i]] = i;
    }

    return [];
}

// https://leetcode.com/problems/length-of-last-word/
int LengthOfLastWord(string s)
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

// https://leetcode.com/problems/plus-one/
int[] PlusOne(int[] digits)
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

// https://leetcode.com/problems/jump-game/
bool CanJump(int[] nums)
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

// https://leetcode.com/problems/move-zeroes/
void MoveZeroes(int[] nums)
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

// https://leetcode.com/problems/asteroid-collision/
int[] AsteroidCollision(int[] asteroids)
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

// https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/
IList<bool> KidsWithCandies(int[] candies, int extraCandies)
{
    var max = candies.Max();
    return candies.Select(q => q + extraCandies >= max).ToList();
}

// https://leetcode.com/problems/average-salary-excluding-the-minimum-and-maximum-salary
double Average(int[] salary)
{
    var max = salary.Max();
    var min = salary.Min();

    return salary.Where(q => q > min && q < max).Average();
}

// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
int MaxProfit(int[] prices)
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

// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
int MaxProfit2(int[] prices)
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

// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
IList<int> FindDisappearedNumbers(int[] nums)
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

// https://leetcode.com/problems/find-all-duplicates-in-an-array/
IList<int> FindDuplicates(int[] nums)
{
    var list = new List<int>();

    for (var i = 0; i < nums.Length; i++)
    {
        var n = Math.Abs(nums[i]);
        nums[n - 1] = -1 * nums[n - 1];

        if (nums[n - 1] > 0)
        {
            list.Add(n);
        }
    }

    return list;
}

// https://leetcode.com/problems/pascals-triangle/
IList<IList<int>> Generate(int numRows)
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
        return [result [
        0]];
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

// https://leetcode.com/problems/pascals-triangle-ii/
IList<int> GetRow(int rowIndex)
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

// https://leetcode.com/problems/sequential-digits/
IList<int> SequentialDigits(int low, int high)
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

// https://leetcode.com/problems/product-of-array-except-self/
int[] ProductExceptSelf(int[] nums)
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

// https://leetcode.com/problems/gas-station/
int CanCompleteCircuit(int[] gas, int[] cost)
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

// https://leetcode.com/problems/rotate-array/description/
void Rotate(int[] nums, int k)
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

// https://leetcode.com/problems/minimum-domino-rotations-for-equal-row/
int MinDominoRotations(int[] tops, int[] bottoms)
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

// https://leetcode.com/problems/subarray-product-less-than-k/
int NumSubarrayProductLessThanK(int[] nums, int k)
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

// https://leetcode.com/problems/jump-game-iii/
bool CanReach(int[] arr, int start)
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

// https://leetcode.com/problems/k-diff-pairs-in-an-array
int FindPairs(int[] nums, int k)
{
    if (nums.Length == 0 || k < 0)
    {
        return 0;
    }

    var dictionary = nums.GroupBy(q => q).ToDictionary(q => q.Key, q => q.Count());

    return k == 0 ? dictionary.Count(q => q.Value >= 2) : dictionary.Count(q => dictionary.ContainsKey(q.Key + k));
}

// https://leetcode.com/problems/degree-of-an-array/
int FindShortestSubArray(int[] nums)
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

// https://leetcode.com/problems/majority-element/
int MajorityElement(int[] nums)
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

// https://leetcode.com/problems/house-robber/
int Rob(int[] nums)
{
    var prev1 = 0;
    var prev2 = 0;

    foreach (var num in nums)
    {
        var dp = Math.Max(prev1, prev2 + num);
        prev2 = prev1;
        prev1 = dp;
    }

    return prev1;
}

// https://leetcode.com/problems/house-robber-ii/
int Rob2(int[] nums)
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

// https://leetcode.com/problems/maximum-product-subarray/
int MaxProduct(int[] nums)
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

// https://leetcode.com/problems/group-anagrams/
IList<IList<string>> GroupAnagrams(string[] strs)
{
    var dictionary = new Dictionary<string, IList<string>>();
    foreach (var str in strs)
    {
        var key = SortString(str);
        if (dictionary.TryGetValue(key, out var list))
        {
            list.Add(str);
        }
        else
        {
            dictionary[key] = [str]
            ;
        }
    }

    return dictionary.Values.ToArray();

    string SortString(string str)
    {
        var chars = str.ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }
}

// https://leetcode.com/problems/132-pattern/
bool Find132pattern(int[] nums)
{
    var possible3rd = new Stack<int>();
    var max3rdNum = int.MinValue;

    for (var i = nums.Length - 1; i >= 0; i--)
    {
        var item = nums[i];

        if (item < max3rdNum)
        {
            return true;
        }

        while (possible3rd.Count > 0 && possible3rd.Peek() < item)
        {
            max3rdNum = possible3rd.Pop();
        }

        possible3rd.Push(item);
    }

    return false;
}

// https://leetcode.com/problems/longest-substring-without-repeating-characters/
int LengthOfLongestSubstring_New(string s)
{
    var hash = new HashSet<char>();
    var left = 0;
    var right = 0;
    var answer = 0;

    while (right < s.Length)
    {
        var item = s[right];
        if (!hash.Contains(item))
        {
            hash.Add(item);
            answer = Math.Max(answer, right - left + 1);
            right++;
        }
        else
        {
            hash.Remove(s[left]);
            left++;
        }
    }

    return answer;
}

// https://leetcode.com/problems/first-missing-positive/
int FirstMissingPositive(int[] nums)
{
    var j = 0;
    var numsLength = nums.Length;

    for (var i = 0; i < numsLength; i++)
    {
        var item = nums[i];
        if (item <= 0)
        {
            (nums[j], nums[i]) = (nums[i], nums[j]);
            j++;
        }
    }

    for (var i = j; i < numsLength; i++)
    {
        var num = Math.Abs(nums[i]);
        if (num <= numsLength - j && nums[num - 1 + j] > 0)
        {
            nums[num - 1 + j] *= -1;
        }
    }

    for (var i = j; i < numsLength; i++)
    {
        if (nums[i] > 0)
        {
            return i - j + 1;
        }
    }

    return numsLength - j + 1;
}

// https://leetcode.com/problems/sliding-window-maximum/
int[] MaxSlidingWindow(int[] nums, int k)
{
    var maxValues = new List<int>();

    var deque = new List<int>();

    for (var i = 0; i < nums.Length; i++)
    {
        if (deque.Count > 0 && deque[0] < i - k + 1)
        {
            deque.RemoveAt(0);
        }

        while (deque.Count > 0 && nums[deque[^1]] <= nums[i])
        {
            deque.RemoveAt(deque.Count - 1);
        }

        deque.Add(i);

        if (i >= k - 1)
        {
            maxValues.Add(nums[deque[0]]);
        }
    }

    return maxValues.ToArray();
}

// https://leetcode.com/problems/add-to-array-form-of-integer/
IList<int> AddToArrayForm(int[] num, int k)
{
    var carry = k;
    for (var i = num.Length - 1; i >= 0; i--)
    {
        var sum = carry + num[i];

        carry = sum / 10;
        var d = sum % 10;

        num[i] = d;
    }

    if (carry <= 0)
    {
        return num;
    }

    var carryList = new Stack<int>();
    for (var i = num.Length - 1; i >= 0; i--)
    {
        carryList.Push(num[i]);
    }

    while (carry > 0)
    {
        carryList.Push(carry % 10);
        carry /= 10;
    }

    return carryList.ToArray();
}

// https://leetcode.com/problems/sqrtx/
int MySqrt(int x)
{
    var left = 1;
    var right = x;

    while (left <= right)
    {
        var mid = left + (right - left) / 2;
        var sqrt = x / mid;

        if (sqrt == mid)
        {
            return mid;
        }

        if (sqrt < mid)
        {
            right = mid - 1;
        }
        else
        {
            left = mid + 1;
        }
    }

    return right;
}

// https://leetcode.com/problems/missing-number/description/
int MissingNumber(int[] nums)
{
    var x = nums.Length;

    for (var i = 0; i < nums.Length; i++)
    {
        x ^= i ^ nums[i];
    }

    return x;

    // arithmetic progression with one missing element
    // nums.Length * (nums.Length + 1) / 2 - nums.Sum();
}

// https://leetcode.com/problems/count-complete-tree-nodes/
int CountNodes(TreeNode? root)
{
    var queue = new Queue<TreeNode>();
    var node = root;

    if (node != null)
    {
        queue.Enqueue(node);
    }

    var count = 0;

    while (queue.Count > 0)
    {
        node = queue.Dequeue();

        count++;

        if (node.left != null)
        {
            queue.Enqueue(node.left);
        }

        if (node.right != null)
        {
            queue.Enqueue(node.right);
        }
    }

    return count;
    // var stack = new Stack<TreeNode>();
    // var node = root;
    //
    // var count = 0;
    //
    // while (stack.Count > 0 || node != null)
    // {
    //     if (node != null)
    //     {
    //         stack.Push(node);
    //         node = node.left;
    //     }
    //     else
    //     {
    //         node = stack.Pop();
    //
    //         count++;
    //
    //         node = node.right;
    //     }
    // }
    //
    // return count;
}

// https://leetcode.com/problems/binary-tree-paths/
IList<string> BinaryTreePaths(TreeNode? root)
{
    var paths = new List<string>();
    var stack = new Stack<TreeNode>();
    var currentPaths = new Stack<string>();

    if (root == null)
    {
        return paths;
    }

    stack.Push(root);
    currentPaths.Push("");

    while (stack.Count > 0)
    {
        var node = stack.Pop();
        var currentPath = currentPaths.Pop();

        if (node.left == null && node.right == null)
        {
            paths.Add(currentPath + node.val);
            continue;
        }

        var path = currentPath + node.val + "->";

        if (node.left != null)
        {
            stack.Push(node.left);
            currentPaths.Push(path);
        }

        if (node.right != null)
        {
            stack.Push(node.right);
            currentPaths.Push(path);
        }
    }

    return paths;
}

// https://leetcode.com/problems/binary-tree-preorder-traversal/
IList<int> PreorderTraversal(TreeNode? root)
{
    var paths = new List<int>();
    var stack = new Stack<TreeNode>();

    if (root == null)
    {
        return paths;
    }

    stack.Push(root);

    while (stack.Count > 0)
    {
        var node = stack.Pop();
        paths.Add(node.val);

        if (node.right != null)
        {
            stack.Push(node.right);
        }

        if (node.left != null)
        {
            stack.Push(node.left);
        }
    }

    return paths;
}

// https://leetcode.com/problems/binary-tree-level-order-traversal/description/
IList<IList<int>> LevelOrder(TreeNode? root)
{
    var stack = new Stack<(TreeNode, int)>();

    if (root == null)
    {
        return []
        ;
    }

    stack.Push((root, 0));

    var list = new List<IList<int>>();

    while (stack.Count > 0)
    {
        (var node, var level) = stack.Pop();

        if (list.Count == level)
        {
            list.Add([]);
        }

        list[level].Add(node.val);

        var nextLevel = level + 1;

        if (node.right != null)
        {
            stack.Push((node.right, nextLevel));
        }

        if (node.left != null)
        {
            stack.Push((node.left, nextLevel));
        }
    }

    return list;
}

// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
IList<IList<int>> ZigzagLevelOrder(TreeNode? root)
{
    var stack = new Stack<(TreeNode, int)>();

    if (root == null)
    {
        return []
        ;
    }

    stack.Push((root, 0));

    var result = new List<IList<int>>();

    while (stack.Count > 0)
    {
        (var node, var level) = stack.Pop();

        if (result.Count == level)
        {
            result.Add([]);
        }

        if (level % 2 == 0)
        {
            result[level].Add(node.val);
        }
        else
        {
            result[level].Insert(0, node.val);
        }

        var nextLevel = level + 1;

        if (node.right != null)
        {
            stack.Push((node.right, nextLevel));
        }

        if (node.left != null)
        {
            stack.Push((node.left, nextLevel));
        }
    }

    return result;
}

// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
TreeNode? SortedArrayToBST(int[] nums)
    => nums.Length == 0 ? null : BuildTreeBySorted(nums, 0, nums.Length - 1);

// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree
TreeNode? BuildTreeBySorted(int[] nums, int left, int right)
{
    if (left > right)
    {
        return null;
    }

    var mid = left + (right - left) / 2;
    var node = new TreeNode(nums[mid])
    {
        left = BuildTreeBySorted(nums, left, mid - 1),
        right = BuildTreeBySorted(nums, mid + 1, right)
    };
    return node;
}

// https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal
TreeNode? BstFromPreorder(int[] preorder)
{
    if (preorder.Length == 0)
    {
        return null;
    }

    var stack = new Stack<TreeNode>();

    var root = new TreeNode(preorder[0]);

    stack.Push(root);

    for (var i = 1; i < preorder.Length; i++)
    {
        TreeNode? lastStack = null;
        while (stack.Count > 0 && stack.Peek().val < preorder[i])
        {
            lastStack = stack.Pop();
        }

        if (lastStack != null)
        {
            lastStack.right = new TreeNode(preorder[i]);
            stack.Push(lastStack.right);
        }
        else
        {
            var peek = stack.Peek();
            peek.left = new TreeNode(preorder[i]);
            stack.Push(peek.left);
        }
    }

    return root;
}

// https://leetcode.com/problems/diameter-of-binary-tree/description/
int DiameterOfBinaryTree(TreeNode? root)
{
    var answer = 0;

    FindDiameter(root);

    return answer;

    int FindDiameter(TreeNode? node)
    {
        if (node == null)
        {
            return 0;
        }

        var left = FindDiameter(node.left);
        var right = FindDiameter(node.right);
        answer = Math.Max(left + right, answer);

        return 1 + Math.Max(left, right);
    }
}

// https://leetcode.com/problems/range-sum-of-bst/description/
int RangeSumBST(TreeNode? root, int low, int high)
{
    var sum = 0;

    if (root == null)
    {
        return sum;
    }

    var stack = new Stack<TreeNode>();
    stack.Push(root);

    while (stack.Count > 0)
    {
        var node = stack.Pop();

        if (node.val >= low && node.val <= high)
        {
            sum += node.val;
        }

        if (node.right != null)
        {
            stack.Push(node.right);
        }

        if (node.left != null)
        {
            stack.Push(node.left);
        }
    }

    return sum;
}

// https://leetcode.com/problems/same-tree/
bool IsSameTree(TreeNode? p, TreeNode? q)
{
    // Best solution imho
    // return (p.val == q.val) && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);

    var queue = new Queue<(TreeNode?, TreeNode?)>();
    queue.Enqueue((p, q));

    while (queue.Count > 0)
    {
        (var nodeP, var nodeQ) = queue.Dequeue();

        if (nodeP == null && nodeQ != null || nodeP != null && nodeQ == null)
        {
            return false;
        }

        if (nodeP == null || nodeQ == null)
        {
            continue;
        }

        if (nodeP.val != nodeQ.val)
        {
            return false;
        }

        queue.Enqueue((nodeP.left, nodeQ.left));
        queue.Enqueue((nodeP.right, nodeQ.right));
    }

    return queue.Count == 0;
}

// https://leetcode.com/problems/squares-of-a-sorted-array/description/
int[] SortedSquares(int[] nums)
{
    var result = new int[nums.Length];
    var left = 0;
    var right = nums.Length - 1;
    var index = right;

    while (left <= right)
    {
        if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
        {
            result[index] = nums[left] * nums[left];
            left++;
        }
        else
        {
            result[index] = nums[right] * nums[right];
            right--;
        }

        index--;
    }

    return result;
}

// https://leetcode.com/problems/intersection-of-two-arrays/
int[] Intersection(int[] nums1, int[] nums2)
    => nums1.Intersect(nums2).Distinct().ToArray();

// https://leetcode.com/problems/intersection-of-two-arrays-ii/
int[] Intersect(int[] nums1, int[] nums2)
{
    var countOfNums = nums1.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var result = new List<int>();

    foreach (var num in nums2)
    {
        if (countOfNums.TryGetValue(num, out var count) && count > 0)
        {
            result.Add(num);
            countOfNums[num]--;
        }
    }

    return result.ToArray();
}

/* 
 * https://www.youtube.com/watch?v=6h-blOjL43s&t=6772s
 * Общие элементы отсортированных массивов.
 * Найти пересечение двух отсортированных массивов.
 * Другими словами, для двух отсортированных массивов найти все элементы, которые встречаются в обоих массивах
 * nums1 = [2,2,5,8,14,19,29,30]
 * nums2 = [-3,0,1,2,2,2,8,19]
 * Output: [2,2,8,19]
 *
 */
int[] IntersectSortedArrays(int[] nums1, int[] nums2)
{
    var index1 = 0;
    var index2 = 0;
    var result = new List<int>();

    while (index1 < nums1.Length && index2 < nums2.Length)
    {
        if (nums1[index1] == nums2[index2])
        {
            result.Add(nums1[index1]);
            index1++;
            index2++;
            continue;
        }

        if (nums1[index1] > nums2[index2])
        {
            index2++;
        }
        else
        {
            index1++;
        }
    }

    return result.ToArray();
}

// https://coderun.yandex.ru/problem/lite-operating-systems
int OperationSystemsCount(int m, (int Start, int End)[] sectors)
{
    var s = sectors.OrderBy(q => q.Start).ToArray();
    var l = new List<int[]>();
    var accumulator = s.First();

    foreach (var sector in s.Skip(1))
    {
        if (sector.Start <= accumulator.End)
        {
            accumulator = accumulator with { End = Math.Max(sector.End, accumulator.End) };
        }
        else
        {
            l.Add([accumulator.Start, sector.End]);
            accumulator = sector;
        }
    }

    return l.Count;
}

// https://leetcode.com/problems/merge-intervals
int[][] Merge(int[][] intervals)
{
    var sortedIntervals = intervals.Select(q => (Start: q[0], End: q[1])).OrderBy(q => q.Start).ToArray();
    var accumulator = sortedIntervals[0];
    var result = new List<int[]>();

    foreach (var i in sortedIntervals.Skip(1))
    {
        if (i.Start <= accumulator.End)
        {
            accumulator = accumulator with { End = Math.Max(accumulator.End, i.End) };
        }
        else
        {
            result.Add([accumulator.Start, accumulator.End]);
            accumulator = i;
        }
    }

    result.Add([accumulator.Start, accumulator.End]);

    return [
    .. result];
}

/*
 РЫБА
 var firstRow = Console.ReadLine()!.Split(' ');
    var n = int.Parse(firstRow[0]);
    var m = int.Parse(firstRow[1]);
    var matrix = new int[n, m];
    for (var i = 0; i < n; i++)
    {
        var line = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        for (var j = 0; j < m; j++)
        {
            matrix[i, j] = line[j];
        }
    }
 
 */

// https://coderun.yandex.ru/problem/cheapest-way
int CheapestWay(int[,] matrix)
{
    var n = matrix.GetLength(0);
    var m = matrix.GetLength(1);
    var cost = new int[n, m];

    for (var i = 0; i < n; i++)
    {
        for (var j = 0; j < m; j++)
        {
            if (i == 0 && j == 0)
            {
                cost[0, 0] = matrix[i, j];
                continue;
            }

            if (j == 0)
            {
                cost[i, j] = matrix[i, j] + cost[i - 1, j];
                continue;
            }

            if (i == 0)
            {
                cost[i, j] = matrix[i, j] + cost[i, j - 1];
                continue;
            }

            cost[i, j] = matrix[i, j] + Math.Min(cost[i - 1, j], cost[i, j - 1]);
        }
    }

    return cost[n - 1, m - 1];
}

// https://coderun.yandex.ru/problem/print-the-route-of-the-maximum-cost
void MaximumCost()
{
    var firstRow = Console.ReadLine()!.Split(' ');
    var n = int.Parse(firstRow[0]);
    var m = int.Parse(firstRow[1]);
    var matrix = new int[n, m];
    for (var i = 0; i < n; i++)
    {
        var line = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        for (var j = 0; j < m; j++)
        {
            matrix[i, j] = line[j];
        }
    }

    var cost = new int[n, m];

    for (var i = 0; i < n; i++)
    {
        for (var j = 0; j < m; j++)
        {
            if (i == 0 && j == 0)
            {
                cost[0, 0] = matrix[i, j];
                continue;
            }

            if (j == 0)
            {
                cost[i, j] = matrix[i, j] + cost[i - 1, j];
                continue;
            }

            if (i == 0)
            {
                cost[i, j] = matrix[i, j] + cost[i, j - 1];
                continue;
            }

            cost[i, j] = matrix[i, j] + Math.Max(cost[i - 1, j], cost[i, j - 1]);
        }
    }

    var stack = new Stack<char>();

    var ii = n - 1;
    var jj = m - 1;
    var max = cost[ii, jj];

    while (ii != 0 || jj != 0)
    {
        if (ii > 0 && jj > 0)
        {
            if (cost[ii - 1, jj] > cost[ii, jj - 1])
            {
                stack.Push('D');
                ii--;
            }
            else
            {
                stack.Push('R');
                jj--;
            }
        }
        else if (ii > 0)
        {
            stack.Push('D');
            ii--;
        }
        else
        {
            jj--;
            stack.Push('R');
        }
    }

    Console.WriteLine(cost[n - 1, m - 1]);
    Console.WriteLine(string.Join(' ', stack));
}

// https://coderun.yandex.ru/problem/knight-move
void KnightMove()
{
    var firstRow = Console.ReadLine()!.Split(' ');
    var n = int.Parse(firstRow[0]);
    var m = int.Parse(firstRow[1]);
    var fields = new int[n + 1, m + 1];
    fields[1, 1] = 1;

    for (var i = 2; i <= n; i++)
    {
        for (var j = 2; j <= m; j++)
        {
            fields[i, j] = fields[i - 1, j - 2] + fields[i - 2, j - 1];
        }
    }

    Console.WriteLine(fields[n, m]);
}

// https://coderun.yandex.ru/problem/cafe
void Cafe()
{
    var n = int.Parse(Console.ReadLine()!);
    var N = n + 1;
    var array = new int[N];
    const int inf = (int)1e9;

    for (var i = 1; i <= n; i++)
    {
        array[i] = int.Parse(Console.ReadLine()!);
    }

    var dp = new int[N, N];

    for (var i = 0; i <= n; i++)
    {
        for (var j = 0; j <= n; j++)
        {
            dp[i, j] = inf;
        }
    }

    dp[0, 0] = 0;
    for (var i = 1; i <= n; i++)
    {
        for (var j = 0; j <= i; j++)
        {
            dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j] + array[i]);
            if (array[i] > 100)
            {
                dp[i, j + 1] = Math.Min(dp[i, j + 1], dp[i - 1, j] + array[i]);
            }

            if (j >= 1)
            {
                dp[i, j - 1] = Math.Min(dp[i, j - 1], dp[i - 1, j]);
            }

            Console.WriteLine();
            PrintMatrix(dp);
            Console.WriteLine();
        }
    }

    var ans = inf;
    for (var j = 0; j <= n; j++)
    {
        ans = Math.Min(ans, dp[n, j]);
    }

    Console.WriteLine(ans);

    void PrintMatrix(int[,] matrix)
    {
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]:G}");
                Console.Write(' ');
            }

            Console.WriteLine();
        }
    }
}

// https://leetcode.com/problems/validate-binary-search-tree
bool IsValidBST(TreeNode? root)
{
    if (root == null)
    {
        return true;
    }

    var stack = new Stack<TreeNode>();
    TreeNode? previous = null;

    while (stack.Count > 0 || root is not null)
    {
        while (root is not null)
        {
            stack.Push(root);
            root = root.left;
        }

        var node = stack.Pop();
        if (previous != null && previous.val >= node.val)
        {
            return false;
        }

        previous = node;
        root = node.right;
    }

    return true;
}

// https://leetcode.com/problems/path-sum/description/
bool HasPathSum(TreeNode? root, int targetSum)
{
    if (root is null)
    {
        return false;
    }

    if (root.left == null && root.right == null)
    {
        return targetSum == root.val;
    }

    var newTarget = targetSum - root.val;
    return HasPathSum(root.left, newTarget) || HasPathSum(root.right, newTarget);
}

// https://youtu.be/R4UHOLZ-bEk?si=VGQlc9bRRj5MZuMY&t=190
int MaxPathSum_Simple(TreeNode? root, int targetSum)
{
    if (root is null)
    {
        return 0;
    }

    var maxLeft = MaxPathSum_Simple(root.left, targetSum - root.val);
    var maxRight = MaxPathSum_Simple(root.right, targetSum - root.val);
    return Math.Max(maxLeft, maxRight) + root.val;
}

// https://youtu.be/R4UHOLZ-bEk?si=335EIzkFHjztk77c&t=698
// https://leetcode.com/problems/binary-tree-maximum-path-sum/
int MaxPathSum(TreeNode? root)
{
    var answer = int.MinValue;
    Helper(root);

    return answer;

    int Helper(TreeNode? node)
    {
        if (node == null)
        {
            return 0;
        }

        var maxLeft = Math.Max(Helper(node.left), 0);
        var maxRight = Math.Max(Helper(node.right), 0);
        answer = Math.Max(answer, maxLeft + maxRight + node.val);

        return Math.Max(maxLeft, maxRight) + node.val;
    }
}

// https://leetcode.com/problems/valid-parentheses/description/
bool IsValid(string s)
{
    if (s.Length % 2 != 0)
    {
        return false;
    }

    var brackets = new Dictionary<char, char>
    {
        { '{', '}' },
        { '(', ')' },
        { '[', ']' }
    };
    var stack = new Stack<char>();
    foreach (var symbol in s)
    {
        if (brackets.ContainsKey(symbol))
        {
            stack.Push(symbol);
        }
        else
        {
            if (stack.Count == 0)
            {
                return false;
            }

            var lastBracket = stack.Pop();
            if (symbol != brackets[lastBracket])
            {
                return false;
            }
        }
    }

    return stack.Count == 0;
}

// https://leetcode.com/problems/decode-string/
string DecodeString(string s)
{
    var numStack = new Stack<int>();
    var stringStack = new Stack<string>();
    var sb = new StringBuilder();
    var n = s.Length;

    for (var i = 0; i < n; i++)
    {
        if (char.IsDigit(s[i]))
        {
            var num = s[i] - '0';

            while (i + 1 < n && char.IsDigit(s[i + 1]))
            {
                num = num * 10 + (s[i + 1] - '0');
                i++;
            }

            numStack.Push(num);
            continue;
        }

        if (s[i] == '[')
        {
            stringStack.Push(sb.ToString());
            sb.Clear();
            continue;
        }

        if (s[i] == ']')
        {
            var repeat = numStack.Pop();
            var tempStrBuilder = new StringBuilder();
            tempStrBuilder.Append(stringStack.Pop());

            for (var r = 0; r < repeat; r++)
            {
                tempStrBuilder.Append(sb);
            }

            sb = tempStrBuilder;
            continue;
        }

        sb.Append(s[i]);
    }

    return sb.ToString();
}

// https://leetcode.com/problems/number-of-islands/
int NumIslands(char[][] grid)
{
    var n = grid.Length;
    var m = grid[0].Length;
    var matrix = new int[n][];

    for (var i = 0; i < n; i++)
    {
        matrix[i] = new int[m];
        for (var j = 0; j < m; j++)
        {
            matrix[i][j] = grid[i][j] - '0';
        }
    }

    var answer = 0;

    for (var i = 0; i < n; i++)
    {
        for (var j = 0; j < m; j++)
        {
            if (matrix[i][j] == 1)
            {
                answer++;
                Dfs(i, j);
            }
        }
    }

    return answer;

    void Dfs(int sr, int sc)
    {
        var queue = new Queue<(int, int)>();
        queue.Enqueue((sr, sc));

        while (queue.Count > 0)
        {
            (var i, var j) = queue.Dequeue();
            if (i < 0 || j < 0 || i >= n || j >= m || matrix[i][j] == 0)
            {
                continue;
            }

            matrix[i][j] = 0;

            queue.Enqueue((i - 1, j));
            queue.Enqueue((i + 1, j));
            queue.Enqueue((i, j - 1));
            queue.Enqueue((i, j + 1));
        }
    }
}

// https://leetcode.com/problems/is-subsequence/
bool IsSubsequence(string s, string t)
{
    if (string.IsNullOrEmpty(s))
    {
        return true;
    }

    var j = 0;
    var i = 0;
    for (i = 0; i < t.Length; i++)
    {
        if (t[i] == s[j])
        {
            if (j + 1 == s.Length)
            {
                return true;
            }

            j++;
        }
    }

    return false;
}

// https://leetcode.com/problems/valid-palindrome
bool IsPalindrome(string s)
{
    var clearString = new string(s.Where(char.IsLetterOrDigit).Select(char.ToLower).ToArray());

    if (string.IsNullOrEmpty(clearString))
    {
        return true;
    }

    var l = 0;
    var r = clearString.Length - 1;

    while (l < r)
    {
        if (clearString[l] != clearString[r])
        {
            return false;
        }

        l++;
        r--;
    }

    return true;
}

// https://leetcode.com/problems/trapping-rain-water
int Trap(int[] height)
{
    var sum = 0;
    var left = 0;
    var right = height.Length - 1;
    var maxLeft = height[left];
    var maxRight = height[right];

    while (left < right)
    {
        if (maxLeft < maxRight)
        {
            left++;
            maxLeft = Math.Max(maxLeft, height[left]);
            sum += maxLeft - height[left];
        }
        else
        {
            right--;
            maxRight = Math.Max(maxRight, height[right]);
            sum += maxRight - height[right];
        }
    }

    return sum;
}

// https://leetcode.com/problems/3sum/
IList<IList<int>> ThreeSum(int[] nums)
{
    var result = new List<IList<int>>();

    if (nums.Length < 3)
    {
        return result;
    }

    if (nums.Length == 3)
    {
        result.Add(nums);
        return result;
    }

    nums = [
    .. nums.Order()];
    for (var i = 0; i < nums.Length - 3; i++)
    {
        if (i == 0 || i > 0 && nums[i] != nums[i - 1])
        {
            var left = i + 1;
            var right = nums.Length - 1;
            var sum = -nums[i];
            while (left < right)
            {
                var currentSum = nums[left] + nums[right];
                if (sum == currentSum)
                {
                    result.Add([nums[i], nums[left], nums[right]]);

                    while (left < right && nums[left] == nums[left + 1])
                    {
                        left++;
                    }

                    while (left < right && nums[right] == nums[right - 1])
                    {
                        right--;
                    }

                    left++;
                    right--;
                }
                else if (sum > currentSum)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }
    }

    return result;
}

// https://leetcode.com/problems/maximum-subarray/
int MaxSubArray(int[] nums)
{
    var current = nums[0];
    var max = nums[0];

    for (var i = 1; i < nums.Length; i++)
    {
        current = Math.Max(nums[i], current + nums[i]);
        max = Math.Max(max, current);
    }

    return max;
}

// https://leetcode.com/problems/subarray-sum-equals-k/
int SubarraySum(int[] nums, int k)
{
    var ans = 0;
    var map = new Dictionary<int, int> { [0] = 1 };

    var sum = 0;
    for (var i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
        if (map.TryGetValue(sum - k, out var count))
        {
            ans += count;
        }

        if (!map.ContainsKey(sum))
        {
            map[sum] = 0;
        }

        map[sum]++;
    }

    return ans;
}

// https://leetcode.com/problems/climbing-stairs/
int ClimbStairs(int n)
{
    if (n == 1)
    {
        return 1;
    }

    var left = 1;
    var right = 1;

    for (var i = 0; i < n - 2; i++)
    {
        var t = left + right;
        left = right;
        right = t;
    }

    return right;
}

// https://leetcode.com/problems/combination-sum/
IList<IList<int>> CombinationSum(int[] candidates, int target)
{
    var result = new List<IList<int>>();

    Helper([], 0, target);

    void Helper(List<int> current, int start, int remain)
    {
        if (remain == 0)
        {
            result.Add(new List<int>(current));
            return;
        }

        if (remain < 0)
        {
            return;
        }

        for (var i = start; i < candidates.Length; i++)
        {
            current.Add(candidates[i]);
            Helper(current, i, remain - candidates[i]);
            current.RemoveAt(current.Count - 1);
        }
    }

    return result;
}

// https://leetcode.com/problems/convert-bst-to-greater-tree/
TreeNode? ConvertBST(TreeNode? root)
{
    var sum = 0;

    var stack = new Stack<TreeNode>();

    if (root == null)
    {
        return root;
    }

    AddToStack(root);

    while (stack.Count > 0)
    {
        var currentNode = stack.Pop();
        sum += currentNode.val;
        currentNode.val = sum;
        AddToStack(currentNode.left);
    }

    return root;

    void AddToStack(TreeNode? node)
    {
        while (node != null)
        {
            stack.Push(node);
            node = node.right;
        }
    }

    /* // Валидное решение через рекурсию reverse inorder traversal
    var sum = 0;

    Convert(root);
    return root;

    void Convert(TreeNode? node)
    {
        if (node == null)
        {
            return;
        }

        Convert(node.right);
        sum += node.val;
        node.val = sum;
        Convert(node.left);
    }*/
}

AverageOfSubtree(BuildTreeFromString("[4,8,5,0,1,null,6]"));

// https://leetcode.com/problems/count-nodes-equal-to-average-of-subtree
int AverageOfSubtree(TreeNode? root)
{
    var result = 0;

    PostOrder(root);

    return result;

    (int, int) PostOrder(TreeNode? node)
    {
        if (node == null)
        {
            return (0, 0);
        }

        (var leftSum, var leftCount) = PostOrder(node.left);
        (var rightSum, var rightCount) = PostOrder(node.right);

        var currentSum = leftSum + rightSum + node.val;
        var currentCount = leftCount + rightCount + 1;

        if (currentSum / currentCount == node.val)
        {
            result++;
        }

        return (currentSum, currentCount);
    }
}

// https://www.codewars.com/kata/57e5279b7cf1aea5cf000359
// решение, которое прошло
int MaxSum(TreeNode? root)
{
    if (root == null)
    {
        return 0;
    }

    if (root.left != null && root.right == null)
    {
        return MaxSum(root.left) + root.val;
    }

    if (root.left == null && root.right != null)
    {
        return MaxSum(root.right) + root.val;
    }

    return Math.Max(MaxSum(root.left), MaxSum(root.right)) + root.val;
}

// https://www.codewars.com/kata/57e5279b7cf1aea5cf000359
// решение, которое красивое
int MaxSumBeauty(TreeNode? root)
    => root switch
    {
        null => 0,
        { left: null, right: null, val: var v } => v,
        { left: null, right: var r, val: var v } => v + MaxSumBeauty(r),
        { left: var l, right: null, val: var v } => v + MaxSumBeauty(l),
        { left: var l, right: var r, val: var v } => v + Math.Max(MaxSumBeauty(l), MaxSumBeauty(r))
    };

// https://www.codewars.com/kata/5800580f8f7ddaea13000025
int SumTree(TreeNode? root)
    => root switch
    {
        null => 0,
        _ => root.val + SumTree(root.left) + SumTree(root.right)
    };


string Longest(string s1, string s2) => new string(s1.ToCharArray().Concat(s2.ToCharArray()).Distinct().Order().ToArray());

// https://www.codewars.com/kata/57e5a6a67fbcc9ba900021cd
TreeNode? ArrayToTree(int[] array)
{
    return array.Length == 0 ? null : BuildTree(0);

    TreeNode? BuildTree(int index)
        => index >= array.Length ? null : new TreeNode(array[index], BuildTree(2 * index + 1), BuildTree(2 * index + 2));
}

// https://leetcode.com/problems/integer-to-roman
string IntToRoman(int num)
{
    (int Value, string Roman)[] values = [
        (1000, "M"), (900, "CM"), (500, "D"),
        (400, "CD"), (100, "C"), (90, "XC"),
        (50, "L"), (40, "XL"), (10, "X"),
        (9, "IX"), (5, "V"), (4, "IV"), (1, "I")];

    var stringBuilder = new StringBuilder();

    for (var i = 0; i < values.Length; i++)
    {
        while (num >= values[i].Value)
        {
            num -= values[i].Value;
            stringBuilder.Append(values[i].Roman);
        }
    }

    return stringBuilder.ToString();
}


// Последовательно идущие единицы
void Temp1()
{
    var array = new byte[int.Parse(Console.ReadLine()!)];

    for (var i = 0; i < array.Length; i++)
    {
        array[i] = byte.Parse(Console.ReadLine()!);
    }

    var maxLength = 0;
    var current = 0;

    for (var index = 0; index < array.Length; index++)
    {
        if (array[index] == 1)
        {
            current++;

            maxLength = System.Math.Max(maxLength, current);
        }
        else
        {
            current = 0;
        }
    }

    Console.WriteLine(maxLength);
}

Temp();


void Temp2()
{
    var n = int.Parse(Console.ReadLine());

    if (n == 0)
    {
        return;
    }

    var prev = int.Parse(Console.ReadLine());
    Console.WriteLine(prev);

    for (var i = 1; i < n; i++)
    {
        var current = int.Parse(Console.ReadLine());

        if (prev == current)
        {
            continue;
        }

        prev = current;
        Console.WriteLine(current);
    }
}

void Temp()
{
    var line = Console.ReadLine().Split(' ');
    var left = line[0];
    var right = line[1];

    if (left.Length != right.Length)
    {
        Console.WriteLine(0);
        return;
    }

    var leftDictionary = left.GroupBy(symbol => symbol).ToDictionary(group => group.Key, group => group.Count());
    var rightDictionary = right.GroupBy(symbol => symbol).ToDictionary(group => group.Key, group => group.Count());

    if (leftDictionary.Count != rightDictionary.Count)
    {
        Console.WriteLine(0);
        return;
    }

    foreach (var item in leftDictionary)
    {
        if (rightDictionary.TryGetValue(item.Key, out var value) && value == item.Value)
        {
            if (value != item.Value)
            {
                Console.WriteLine(0);
                return;
            }
        }

        Console.WriteLine(0);
        return;
    }

    Console.WriteLine(1);
}
