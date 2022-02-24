export const twoSumsN2 = (numbers: number[], k: number): number[] => {
  for (let i = 0; i < numbers.length; i++) {
    for (let j = i + 1; j < numbers.length; j++) {
      if (numbers[i] + numbers[j] == k) return [numbers[i], numbers[j]];
    }
  }

  return [];
};

export const twoSumsSet = (numbers: number[], k: number): number[] => {
  let set = new Set<number>();
  for (let i = 0; i < numbers.length; i++) {
    const numberToFind = k - numbers[i];
    if(set.has(numberToFind)) {
      return [numberToFind, numbers[i]];
    }

    set.add(numbers[i]);
  }

  return [];
};

export const twoSumsBinarySearch = (numbers: number[], k: number): number[] => {
  for (let i = 0; i < numbers.length; i++) {
    const numberToFind = k - numbers[i];
    let l = i + 1, r = numbers.length - 1;
    while(l <= r) {
      const middle = Math.floor(l + (r - l) * 0.5);
      if(numbers[middle] == numberToFind) {
        return [numbers[i], numbers[middle]];
      }
      if(numberToFind < numbers[middle]) {
        r = middle - 1;
      } else {
        l = middle + 1;
      }
    }
  }

  return [];
};

export const twoSumsPointers = (numbers: number[], k: number): number[] => {
  let l = 0, r = numbers.length - 1;
  while(l < r) {
    const sum = numbers[l] + numbers[r];
    if(sum == k) return [numbers[l], numbers[r]];

    if(sum < k) {
      l++;
    } else {
      r--;
    }
  }

  return [];
};
