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

const shortestPath = (maze: string): number | boolean => {
  
  const mazeArray = maze.split('\n').map(r => r.split(""));
  const lastIndex = mazeArray.length - 1;
  const possiblePath = [[1, 0], [-1, 0], [0, 1], [0, -1]];

  const startX = 0;
  const startY = 0;

  let cellsToProcess = [{
    x: startX, y: startY, step: 0
  }];

  while(cellsToProcess.length) {
    const {x, y, step} = cellsToProcess.shift()!;
    if(x === lastIndex && y === lastIndex) {
      return step;
    }
    
    mazeArray[x][y] = "W";

    for(let i = 0; i < possiblePath.length; i++ ) {
      const [deltaX, deltaY] = possiblePath[i];
      const nextX = x + deltaX;
      const nextY = y + deltaY;

      if(mazeArray[nextX] && mazeArray[nextX][nextY] && mazeArray[nextX][nextY] !== "W") {
          cellsToProcess.push({x: nextX, y: nextY, step: step + 1});
          mazeArray[nextX][nextY] = "W"
      }
    }
  }

  return false;
};

export { reachTheExit, shortestPath };