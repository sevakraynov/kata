export const minimumTotal = (triangle: number[][]): number => {

  const n = triangle[triangle.length - 1].length;
  const path: number[][] = [...new Array(2).fill(Number.MAX_VALUE)].map(_ => new Array(n).fill(Number.MAX_VALUE));
  path[0][0] = triangle[0][0];

  for (let i = 1; i < triangle.length; i++) {
    for (let j = 0; j < triangle[i].length; j++) {
      const prev = (i - 1) % 2;
      path[i % 2][j] = Math.min(path[prev][j], path[prev][Math.max(j - 1, 0)]) + triangle[i][j];
    }
  }

  return Math.min(...path[(n - 1) % 2]);
};
