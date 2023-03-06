import { maxAreaOfIsland } from "./max-area-of-island";

const cases: { grid: number[][]; maxArea: number }[] = [
  {
    grid: [
      [0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0],
      [0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0],
      [0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0],
      [0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0],
      [0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0],
    ],
    maxArea: 6,
  },
  {
    grid: [[0,0,0,0,0,0,0,0]],
    maxArea: 0
  }
];

describe("max-area-of-island", () => {

  test.each(cases)("case #%#", ({ grid, maxArea }) => {
    const result = maxAreaOfIsland(grid);
    expect(result).toBe(maxArea);
  });
});
