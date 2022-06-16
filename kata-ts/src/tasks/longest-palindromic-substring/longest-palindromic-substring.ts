export const longestPalindrome = (s: string): string => {
  let start = 0,
    end = 0;

  const expandFromCenter = (str: string, l: number, r: number) => {
    while (l >= 0 && r < str.length && str[l] === str[r]) {
      l--;
      r++;
    }

    return r - l - 1;
  };

  for (let i = 0; i < s.length; i++) {
    let len1 = expandFromCenter(s, i, i);
    let len2 = expandFromCenter(s, i, i + 1);
    let length = Math.max(len1, len2);

    if (length > end - start) {
      start = Math.ceil(i - (length - 1) * 0.5);
      end = Math.floor(i + length * 0.5);
    }
  }

  return s.substring(start, end + 1);
};
