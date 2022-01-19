export const findJudge = (n: number, trust: number[][]): number => {
  const count = new Array(n + 1).fill(0);

  for (let i = 0; i < trust.length; i++) {
    count[trust[i][0]]--;
    count[trust[i][1]]++;
  }

  for (let j = 1; j < n + 1; j++) {
    if (count[j] === n - 1) return j;
  }

  return -1;
};
