export const singleNonDuplicate = (nums: number[]): number => {
  const numsLength = nums.length;
  let findedNonDuplicate: number = 0;

  for (let i = 0; i < numsLength; i += 2) {
    const el = nums[i];
    if (nums[i + 1] === undefined || el !== nums[i + 1]) {
      findedNonDuplicate = el;
      break;
    }
  }

  return findedNonDuplicate;
};
