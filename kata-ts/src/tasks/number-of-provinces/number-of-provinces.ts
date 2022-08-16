export const findCircleNum = (isConnected: number[][]): number => {
  const cities = isConnected.length;
  let provinces = 0;
  let visit = new Array(cities).fill(false);

  function dfs(currentCity: number, cities: number) {
    visit[currentCity] = true;
    for (let neighborCity = 0; neighborCity < cities; neighborCity++) {
      if (
        neighborCity != currentCity &&
        isConnected[currentCity][neighborCity] &&
        !visit[neighborCity]
      ) {
        dfs(neighborCity, cities);
      }
    }
  }

  for (let city = 0; city < cities; city++) {
    if (!visit[city]) {
      provinces++;
      dfs(city, cities);
    }
  }

  return provinces;
};
