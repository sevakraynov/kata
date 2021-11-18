const uniquePaths = (m: number, n: number): number => {
  let amountPathsFinds: number[][] = Array.from(Array(m + 1), (_) => Array(n + 1).fill(0));

  const findPaths = (m: number, n: number, arr: number[][]): number => {
    if (m < 1 || n < 1) {
      return 0;
    }

    if (m == 1 && n == 1) {
      return 1;
    }

    if (amountPathsFinds[m][n] != 0) {
      return amountPathsFinds[m][n];
    }

    amountPathsFinds[m][n] =
      findPaths(m - 1, n, amountPathsFinds) + findPaths(m, n - 1, amountPathsFinds);
    return amountPathsFinds[m][n];
  };

  return findPaths(m, n, amountPathsFinds);
};

export default uniquePaths;
