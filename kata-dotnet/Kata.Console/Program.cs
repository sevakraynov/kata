#pragma warning disable CA1822

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interval = (int Start, int End);

ConsoleEx.Debugify(
    new Solution().IntersectSortedArrays(
        new[] { 2, 2, 5, 8, 14, 19, 29, 30 },
        new[] { -3, 0, 1, 2, 2, 2, 8, 19 }));

List<int?> ParseTreeNodeStrIntoValueArray(string treeNodeStr)
{
    List<int?> valueArray = new();

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

public static class ConsoleEx
{
    public static void Debugify<T>(IEnumerable<T> list, string glue = "\n")
        => Console.WriteLine(string.Join(glue, list.Select(x => x?.ToString())));
}


// Console.WriteLine(new Solution().ReverseString(2.0, 2));


public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
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

    public IList<IList<string>> GroupAnagrams(string[] strs)
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
                dictionary[key] = new List<string> { str };
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

    public bool Find132pattern(int[] nums)
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

    public int LengthOfLongestSubstring_New(string s)
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

    public int FirstMissingPositive(int[] nums)
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

    public int[] MaxSlidingWindow(int[] nums, int k)
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

    public IList<int> AddToArrayForm(int[] num, int k)
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

    public int MySqrt(int x)
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

    public int MissingNumber(int[] nums)
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
    public int CountNodes(TreeNode? root)
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
    public IList<string> BinaryTreePaths(TreeNode? root)
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
    public IList<int> PreorderTraversal(TreeNode? root)
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
    public IList<IList<int>> LevelOrder(TreeNode? root)
    {
        var stack = new Stack<(TreeNode, int)>();

        if (root == null)
        {
            return new List<IList<int>>();
        }

        stack.Push((root, 0));

        var dictionary = new List<IList<int>>();

        while (stack.Count > 0)
        {
            (var node, var level) = stack.Pop();

            if (dictionary.Count == level)
            {
                dictionary.Add(new List<int>());
            }

            dictionary[level].Add(node.val);

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

        return dictionary;
    }

    // https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
    public IList<IList<int>> ZigzagLevelOrder(TreeNode? root)
    {
        var stack = new Stack<(TreeNode, int)>();

        if (root == null)
        {
            return new List<IList<int>>();
        }

        stack.Push((root, 0));

        var result = new List<IList<int>>();

        while (stack.Count > 0)
        {
            (var node, var level) = stack.Pop();

            if (result.Count == level)
            {
                result.Add(new List<int>());
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
    public TreeNode? SortedArrayToBST(int[] nums)
        => nums.Length == 0 ? null : BuildTreeBySorted(nums, 0, nums.Length - 1);

    private TreeNode? BuildTreeBySorted(int[] nums, int left, int right)
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
    public TreeNode? BstFromPreorder(int[] preorder)
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
    public int DiameterOfBinaryTree(TreeNode? root)
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
    public int RangeSumBST(TreeNode? root, int low, int high)
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
    public bool IsSameTree(TreeNode? p, TreeNode? q)
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
    public int[] SortedSquares(int[] nums)
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
    public int[] Intersection(int[] nums1, int[] nums2)
        => nums1.Intersect(nums2).Distinct().ToArray();

    // https://leetcode.com/problems/intersection-of-two-arrays-ii/
    public int[] Intersect(int[] nums1, int[] nums2)
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
    public int[] IntersectSortedArrays(int[] nums1, int[] nums2)
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
    
    public int OperationSystemsCount(int m, Interval[] sectors)
    {
        var s = sectors.OrderBy(q => q.Start).ToArray();
        var l = new List<Interval>();
        var accumulator = s.First();

        foreach (var sector in s.Skip(1))
        {
            if (sector.Start <= accumulator.End)
            {
                accumulator = (accumulator.Start, End: Math.Max(sector.End, accumulator.End));
            }
            else
            {
                l.Add(accumulator);
                accumulator = sector;
            }
        }
        
        return l.Count;
    }

    // https://leetcode.com/problems/merge-intervals
    private record Interval(int Start, int End);
    public int[][] Merge(int[][] intervals)
    {
        var nintervals = intervals.Select(q => new Interval(q[0], q[1])).OrderBy(q => q.Start).ToArray();
        var accumularor = nintervals[0];
        var result = new List<int[]>();

        foreach (var i in nintervals.Skip(1))
        {
            if (i.Start <= accumularor.End)
            {
                accumularor = accumularor with { End = Math.Max(accumularor.End, i.End) };
            }
            else
            {
                result.Add([accumularor.Start, accumularor.End]);
                accumularor = i;
            }
        }
        
        result.Add([accumularor.Start, accumularor.End]);
        
        return result.ToArray();
    }
}

