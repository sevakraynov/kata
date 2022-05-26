import { maxArea } from "./container-with-most-water";

describe("container-with-most-water", () => {
  test.each`
    height                         | expected
    ${[1, 8, 6, 2, 5, 4, 8, 3, 7]} | ${49}
    ${[1, 1]}                      | ${1}
  `("returns $expected when input $height", ({ height, expected }) => {
    const area = maxArea(height);
    expect(area).toBe(expected);
  });
});
