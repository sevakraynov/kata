const maxSum = (arr: number[], ranges: [number, number][]) => {
  const sumFrom0ToN = [arr[0]];

  for (let i = 1; i < arr.length; i++) {
    sumFrom0ToN[i] = sumFrom0ToN[i - 1] + arr[i];
  }

  let currentMaxSum = -Infinity;
  for (let i = 0; i < ranges.length; i++) {
    const [start, end] = ranges[i];
    const sum = sumFrom0ToN[end] - (sumFrom0ToN[start - 1] || 0);
    if (sum > currentMaxSum) {
      currentMaxSum = sum;
    }
  }

  return currentMaxSum;
};

export default maxSum;
