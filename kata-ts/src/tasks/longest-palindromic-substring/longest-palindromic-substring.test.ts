import { longestPalindrome } from "./longest-palindromic-substring";

describe("longest-palindromic-substring", () => {
  test.each`
    str              | expected
    ${"cbbd"}        | ${"bb"}
    ${"babad"}       | ${"aba"}
    ${"mississippi"} | ${"ississi"}
  `("returns $expected when input $str", ({ str, expected }) => {
    const subPalindrome = longestPalindrome(str);
    expect(subPalindrome).toBe(expected);
  });
});
