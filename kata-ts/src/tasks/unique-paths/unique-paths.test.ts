import uniquePaths from "./unique-paths";

describe("valid parentheses tests", () => {
  test.each`
    m     | n    | expected
    ${3}  | ${2} | ${3}
    ${3}  | ${7} | ${28}
    ${7}  | ${3} | ${28}
    ${3}  | ${3} | ${6}
    ${51} | ${9} | ${1916797311}
  `("returns $expected unique paths when input $m x $n grid", ({ m, n, expected }) => {
    const u = uniquePaths(m, n);
    expect(u).toBe(expected);
  });
});
