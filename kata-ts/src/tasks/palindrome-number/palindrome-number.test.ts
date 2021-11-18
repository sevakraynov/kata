import palindrome from "./palindrome-number";

describe("palindrome tests", () => {
  test.each`
    number    | expected
    ${0}      | ${true}
    ${10}     | ${false}
    ${11}     | ${true}
    ${121}    | ${true}
    ${21212}  | ${true}
    ${2222}   | ${true}
    ${22220}  | ${false}
    ${-22220} | ${false}
  `("returns $expected when $number passed to function", ({ number, expected }) => {
    const isPalindrome = palindrome(number);
    expect(isPalindrome).toBe(expected);
  });
});
