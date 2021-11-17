const dailyTemperatures = (temperatures: number[]): number[] => {
  const answer: number[] = new Array(temperatures.length).fill(0);
  const stack: [number, number][] = [];

  for (let index = temperatures.length - 1; index >= 0; index--) {
    const element = temperatures[index];
    let topOnStack = stack.length - 1;

    while (topOnStack >= 0 && stack[topOnStack][0] <= element) {
      stack.pop();
      topOnStack = stack.length - 1;
    }

    if (stack.length > 0) {
      answer[index] = stack[topOnStack][1] - index;
    }

    stack.push([element, index]);
  }

  return answer;
};

export default dailyTemperatures;
