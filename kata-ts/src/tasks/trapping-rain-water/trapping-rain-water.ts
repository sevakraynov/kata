export const trap = (height: number[]): number => {
  let sum = 0,
    left = 0,
    right = height.length - 1,
    maxLeft = height[left],
    maxRight = height[right];

  while (left < right) {
    if (maxLeft < maxRight) {
      left++;
      maxLeft = Math.max(maxLeft, height[left]);
      sum += maxLeft - height[left];
    } else {
      right--;
      maxRight = Math.max(maxRight, height[right]);
      sum += maxRight - height[right];
    }
  }

  return sum;
};
