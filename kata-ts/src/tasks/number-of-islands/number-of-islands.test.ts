import { numIslands } from "./number-of-islands";

const cases: {
  numOfIslands: number;
  grid: string[][];
}[] = [
  {
    numOfIslands: 1,
    grid: [
      ["1", "1", "1", "1", "0"],
      ["1", "1", "0", "1", "0"],
      ["1", "1", "0", "0", "0"],
      ["0", "0", "0", "0", "0"],
    ],
  },
  {
    numOfIslands: 3,
    grid: [
      ["1", "1", "0", "0", "0"],
      ["1", "1", "0", "0", "0"],
      ["0", "0", "1", "0", "0"],
      ["0", "0", "0", "1", "1"],
    ],
  },
];

describe("number-of-islands", () => {
  test.each(cases)("case #%#", ({ grid, numOfIslands }) => {
    const result = numIslands(grid);
    expect(result).toBe(numOfIslands);
  });
});
