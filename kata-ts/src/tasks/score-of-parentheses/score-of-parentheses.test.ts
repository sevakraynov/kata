import { scoreOfParentheses } from "./score-of-parentheses";

describe("score-of-parentheses", () => {
  test.each`
    input           | expected
    ${"()"}         | ${1}
    ${"(())"}       | ${2}
    ${"()()"}       | ${2}
    ${"(())(()())"} | ${6}
  `("returns $expected when $input passed to function", ({ input, expected }) => {
    expect(scoreOfParentheses(input)).toEqual(expected);
  });
});
