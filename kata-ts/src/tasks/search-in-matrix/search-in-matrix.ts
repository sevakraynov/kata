export const searchMatrix = (matrix: number[][], target: number): boolean => {
  let i = 0,
    j = matrix[0].length - 1;

  while (i < matrix.length && j >= 0) {
    if (matrix[i][j] == target) {
      return true;
    }

    if (matrix[i][j] > target) {
      j--;
      continue;
    }

    if (matrix[i][j] < target) {
      i++;
      continue;
    }
  }

  return false;
};
