import { findJudge } from "./find-the-town-judge";

describe("find judge tests", () => {
  test.each`
    n    | trust                       | judge
    ${2} | ${[[1, 2]]}                 | ${2}
    ${3} | ${[[1, 3], [2, 3]]}         | ${3}
    ${3} | ${[[1, 2], [2, 3]]}         | ${-1}
    ${3} | ${[[1, 3], [2, 3], [3, 1]]} | ${-1}
  `("returns $expected when $number passed to function", ({ n, trust, judge }) => {
    const j = findJudge(n, trust);
    expect(j).toBe(judge);
  });
});
