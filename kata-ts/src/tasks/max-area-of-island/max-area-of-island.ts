export const maxAreaOfIsland = (grid: number[][]): number => {
  let n = grid.length;
  let m = grid[0].length;

  let maxArea = 0;
  for (let i = 0; i < n; i++) {
    for (let j = 0; j < m; j++) {
      const element = grid[i][j];
      if (element === 1) {
        let area = bfs(grid, i, j, n, m);
        maxArea = area > maxArea ? area : maxArea;
      }
    }
  }

  function bfs(grid: number[][], sr: number, sv: number, n: number, m: number): number {
    let queue: [number, number][] = [];
    queue.push([sr, sv]);

    let area = 0;

    while (queue.length > 0) {
      let [i, j] = queue.pop()!;

      if (i < 0 || i >= n || j < 0 || j >= m || grid[i][j] !== 1 || grid[i][j] === -1) {
        continue;
      } else {
        grid[i][j] = -1;

        area++;
        queue.push([i + 1, j]);
        queue.push([i - 1, j]);
        queue.push([i, j + 1]);
        queue.push([i, j - 1]);
      }
    }

    return area;
  }

  return maxArea;
};
