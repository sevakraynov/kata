import { trap } from "./trapping-rain-water";

describe("trapping-rain-water", () => {
  test.each`
    height                                  | expected
    ${[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]} | ${6}
    ${[4, 2, 0, 3, 2, 5]}                   | ${9}
  `("returns $expected when input $height", ({ height, expected }) => {
    const sum = trap(height);
    expect(sum).toBe(expected);
  });
});
