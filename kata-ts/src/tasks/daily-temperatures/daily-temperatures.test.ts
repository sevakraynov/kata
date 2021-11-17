import dailyTemperatures from "./daily-temperatures";

describe("valid parentheses tests", () => {
  test.each`
    temperatures                        | expected
    ${[13, 12, 15, 11, 9, 12, 16]}      | ${[2, 1, 4, 2, 1, 1, 0]}
    ${[73, 74, 75, 71, 69, 72, 76, 73]} | ${[1, 1, 4, 2, 1, 1, 0, 0]}
    ${[30, 40, 50, 60]}                 | ${[1, 1, 1, 0]}
  `("returns $expected when $temperatures passed to function", ({ temperatures, expected }) => {
    const daily = dailyTemperatures(temperatures);
    expect(daily).toStrictEqual(expected);
  });
});
