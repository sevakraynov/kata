export const searchRange = (nums: number[], target: number): number[] => {
  return [findStartIndex(nums, target), findEndIndex(nums, target)];
};

const findEndIndex = (nums: number[],target: number): number => {
  let index = -1;
  let start = 0, end = nums.length - 1;

  while(start <= end) {
    let middleIndex = start + Math.round((end - start) * 0.5);
    if(target >= nums[middleIndex]) {
      start = middleIndex + 1;
    } else {
      end = middleIndex - 1;
    }

    if(target == nums[middleIndex]) index = middleIndex;
  }

  return index;
}

const findStartIndex = (nums: number[],target: number): number => {
  let index = -1;
  let start = 0, end = nums.length - 1;

  while(start <= end) {
    let middleIndex = start + Math.round((end - start) * 0.5);
    if(target <= nums[middleIndex]) {
      end = middleIndex - 1;
    } else {
      start = middleIndex + 1;
    }

    if(target == nums[middleIndex]) index = middleIndex;
  }

  return index;
}
