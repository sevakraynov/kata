export const diagonalSum = (mat: number[][]): number => {
  const center = Math.floor(mat.length * 0.5);

  let sum = 0;

  for (let index = 0, j = mat.length - 1; index < mat.length && j >= 0; index++, j--) {
    sum += mat[index][index] + mat[j][index];
  }

  return mat.length % 2 != 0 ? sum - mat[center][center] : sum;
};
