const isPalindrome = (x: number): boolean => {
  if (x < 0 || (x != 0 && x % 10 === 0)) {
    return false;
  }

  let n = x.toString();

  let l = 0,
    r = n.length - 1;

  while (l != r) {
    if (n[l] !== n[r]) {
      return false;
    }
    if (r - l == 1) {
      return true;
    }

    l++;
    r--;
  }

  return true;
};

export default isPalindrome;
