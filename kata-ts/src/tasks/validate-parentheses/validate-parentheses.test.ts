import { validParentheses } from "./validate-parentheses";

describe("valid parentheses tests", () => {
  test.each`
    str         | expected
    ${"()"}     | ${true}
    ${"(())"}   | ${true}
    ${"()()"}   | ${true}
    ${"())"}    | ${false}
    ${"(()"}    | ${false}
    ${"{}()"}   | ${true}
    ${"[]{}()"} | ${true}
    ${"[{()}]"} | ${true}
    ${"[(){}]"} | ${true}
    ${"[){}]"}  | ${false}
    ${"[{]"}    | ${false}
    ${"]"}      | ${false}
    ${"{"}      | ${false}
  `("returns $expected when $str passed to function", ({ str, expected }) => {
    expect(validParentheses(str)).toEqual(expected);
  });

  test("empty string return true", () => {
    expect(validParentheses("")).toBeTruthy();
  });

  test("long empty string return true", () => {
    expect(validParentheses("".repeat(140))).toBeTruthy();
  });

  test("long string with spaces return true", () => {
    expect(validParentheses(`(${"".repeat(15)}(${"".repeat(15)})${"".repeat(15)})`)).toBeTruthy();
  });
});
