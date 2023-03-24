import { maxDistToClosest } from "./maximize-distance-to-closest-person";

const cases: { seats: number[]; maxDist: number }[] = [
  { seats: [1, 0, 0, 0, 1, 0, 1], maxDist: 2 },
  { seats: [1, 0, 0, 0], maxDist: 3 },
  { seats: [0, 0, 0, 0, 1], maxDist: 4 },
];

describe("maximize-distance-to-closest-person", () => {
  test.each(cases)("case #%#", ({ seats, maxDist }) => {
    const result = maxDistToClosest(seats);
    expect(result).toBe(maxDist);
  });
});
