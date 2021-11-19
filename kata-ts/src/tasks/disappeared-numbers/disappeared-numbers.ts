const findDisappearedNumbers = (nums: number[]): number[] => {
  const arrayLength = nums.length;
  let findNumbers: boolean[] = Array(arrayLength).fill(false);

  for (let i = 0; i < arrayLength; i++) {
    const num = nums[i];
    if (!findNumbers[num - 1]) {
      findNumbers[num - 1] = true;
    }
  }

  const answer: number[] = [];

  for (let i = 0; i < arrayLength; i++) {
    const el = findNumbers[i];
    if (!el) {
      answer.push(i + 1);
    }
  }

  return answer;
};

export default findDisappearedNumbers;
