export let reverse = (x: number): number => {
  const minValue = -2147483648;
  const maxValue = 2147483647;
  const sign = x < 0 ? -1 : 1;

  let left = 0;
  let right = x < 0 ? x * -1 : x;
  while (right > 0) {
    left = left * 10 + (right % 10);
    right = Math.floor(right / 10);
  }

  const result = left * sign;
  return result > maxValue || result < minValue ? 0 : result;
};
