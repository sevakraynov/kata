export const floodFill = (image: number[][], sr: number, sc: number, color: number): number[][] => {
  let oldColor = image[sr][sc];
  if (oldColor === color) return image;

  let queue: [number, number][] = [];
  let n = image.length;
  let m = image[0].length;
  queue.push([sr, sc]);

  while (queue.length > 0) {
    let [i, j] = queue.pop()!;

    if (i < 0 || i >= n || j < 0 || j >= m || image[i][j] !== oldColor) {
      continue;
    } else {
      image[i][j] = color;

      queue.push([i + 1, j]);
      queue.push([i - 1, j]);
      queue.push([i, j + 1]);
      queue.push([i, j - 1]);
    }
  }

  return image;
};
