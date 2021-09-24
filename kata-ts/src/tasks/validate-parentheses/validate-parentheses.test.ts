import validParentheses from "./validate-parentheses";

describe("valid parentheses tests", () => {
  test(' "()" return true', () => {
    expect(validParentheses("()")).toBeTruthy();
  });

  test(' "())" return false', () => {
    expect(validParentheses("())")).toBeFalsy();
  });

  test(' "(()" return false', () => {
    expect(validParentheses("(()")).toBeFalsy();
  });

  test(' "(())" return true', () => {
    expect(validParentheses("(())")).toBeTruthy();
  });

  test(' "()()" return true', () => {
    expect(validParentheses("()()")).toBeTruthy();
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
