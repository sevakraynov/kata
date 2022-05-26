export const searchRange = (nums: number[], target: number): number[] => {
  return [search(nums, target, true), search(nums, target, false)];
};

const search = (nums: number[], target: number, fromLeftToRight: boolean) => {
  let i = -1;
  let start = 0,
    end = nums.length - 1;

  while (start <= end) {
    let m = start + Math.round((end - start) * 0.5);
    if (target < nums[m]) {
      end = m - 1;
    }

    if (target > nums[m]) {
      start = m + 1;
    }

    if (target === nums[m]) {
      i = m;

      if (fromLeftToRight) {
        end = m - 1;
      } else {
        start = m + 1;
      }
    }
  }

  return i;
};
