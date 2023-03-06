export const numIslands = (grid: string[][]): number => {
  let count = 0;
  let n = grid.length;
  let m = grid[0].length;

  for (let i = 0; i < n; i++) {
    for (let j = 0; j < m; j++) {
      const element = grid[i][j];
      if (element === "1") {
        count += 1;
        bfs(grid, i, j, n, m);
      }
    }
  }

  function bfs(grid: string[][], sr: number, sv: number, n: number, m: number) {
    let queue: [number, number][] = [];

    queue.push([sr, sv]);

    while (queue.length > 0) {
      let [i, j] = queue.pop()!;

      if (i < 0 || i >= n || j < 0 || j >= m || grid[i][j] !== "1" || grid[i][j] === "#") {
        continue;
      } else {
        grid[i][j] = "#";

        queue.push([i + 1, j]);
        queue.push([i - 1, j]);
        queue.push([i, j + 1]);
        queue.push([i, j - 1]);
      }
    }
  }

  return count;
};
