export const maxDistToClosest = (seats: number[]): number => {
  let max = 0;
  let count = 0;
  let start = 0;

  if (seats[start] === 0) {
    while (seats[start] === 0) {
      count++;
      start++;
    }

    max = count;
    count = 0;
  }

  for (let i = start; i < seats.length; i++) {
    const current = seats[i];

    if (current === 0 && i == seats.length - 1) {
      count++;
      return Math.max(max, count);
    }

    if (current === 1) {
      count = 0;
    } else {
      count++;
      max = Math.max(max, Math.ceil(count * 0.5));
    }
  }

  return max;
};
