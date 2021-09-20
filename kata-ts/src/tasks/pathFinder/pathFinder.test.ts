import { reachTheExit, shortestPath } from "./pathFinder";

describe("path finder #1: can you reach the exit?", () => {
  test("basic test #1", () => {
    const maze = `.W.
.W.
...`;
    expect(reachTheExit(maze)).toBeTruthy();
  });

  test("basic test #2", () => {
    const maze = `.W.
.W.
W..`;

    expect(reachTheExit(maze)).toBeFalsy();
  });

  test("basic test #3", () => {
    const maze = `......
......
......
......
......
......`;

    expect(reachTheExit(maze)).toBeTruthy();
  });

  test("basic test #4", () => {
    const maze = `......
......
......
......
.....W
....W.`;

    expect(reachTheExit(maze)).toBeFalsy();
  });
});

describe("path finder #2: shortest path", () => {
  test("basic test #1", () => {
    const maze = `.W.
.W.
...`;
    expect(shortestPath(maze)).toBe(4);
  });

  test("basic test #2", () => {
    const maze = `.W.
.W.
W..`;

    expect(shortestPath(maze)).toBeFalsy();
  });

  test("basic test #3", () => {
    const maze = `......
......
......
......
......
......`;

    expect(shortestPath(maze)).toBe(10);
  });

  test("basic test #4", () => {
    const maze = `......
......
......
......
.....W
....W.`;

    expect(shortestPath(maze)).toBeFalsy();
  });
});
