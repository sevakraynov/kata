const reachTheExit = (maze: string): boolean => {
  
  const mazeArray = maze.split('\n').map(r => r.split(""));
  const lastIndex = mazeArray.length - 1;

  const startX = 0;
  const startY = 0;

  let cellsToProcess = [
    [startX, startY]
  ];

  while(cellsToProcess.length) {
    const [x, y] = cellsToProcess.pop() || [];
    const possiblePath = [[x + 1, y], [x - 1, y], [x, y + 1], [x, y - 1]];
    mazeArray[x][y] = "*";

    for(let i = 0; i < possiblePath.length; i++ ) {
      const [nextX, nextY] = possiblePath[i];
      if(mazeArray[nextX] && mazeArray[nextX][nextY] === ".") {
          cellsToProcess.push([nextX, nextY]);
      }
    }
  }

  return mazeArray[lastIndex][lastIndex] === "*";
}

export { reachTheExit };