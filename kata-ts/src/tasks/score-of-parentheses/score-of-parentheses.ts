export const scoreOfParentheses = (s: string): number => {
  let stack: number[] = [];
  const strLength = s.length;
  let score = 0;
  for (let i = 0; i < strLength; i++) {
    if (s[i] === "(") {
      stack.push(score);
      score = 0;
    } else {
      const top = stack.pop()!;
      score = top + Math.max(score * 2, 1);
    }
  }

  return score;
};
