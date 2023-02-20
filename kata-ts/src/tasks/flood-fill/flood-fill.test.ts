import { floodFill } from "./flood-fill";

describe("flood-fill", () => {
  test.each`
    image                                | sr   | sc   | color | expected
    ${[[1, 1, 1], [1, 1, 0], [1, 0, 1]]} | ${1} | ${1} | ${2}  | ${[[2, 2, 2], [2, 2, 0], [2, 0, 1]]}
    ${[[0, 0, 0], [0, 0, 0]]}            | ${0} | ${0} | ${0}  | ${[[0, 0, 0], [0, 0, 0]]}
    ${[[0, 0, 0], [0, 1, 0]]}            | ${0} | ${0} | ${2}  | ${[[2, 2, 2], [2, 1, 2]]}
  `("returns $expected when $image passed to function", ({ image, sr, sc, color, expected }) => {
    const result = floodFill(image, sr, sc, color);
    expect(result).toEqual(expected);
  });
});
