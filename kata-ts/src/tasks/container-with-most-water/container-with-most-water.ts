export const maxArea = (height: number[]): number => {
  let left = 0,
    right = height.length - 1,
    max = 0;

  while (left < right) {
    const l = right - left;
    if (height[left] < height[right]) {
      max = Math.max(max, height[left] * l);
      left++;
    } else {
      max = Math.max(max, height[right] * l);
      right--;
    }
  }

  return max;
};
