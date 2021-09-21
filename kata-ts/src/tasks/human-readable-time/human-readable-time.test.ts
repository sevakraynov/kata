import humanReadableTime from "./human-readable-time";

describe("human readable time tests", () => {
  test("pass 0 seconds return 00:00:00", () => {
    expect(humanReadableTime(0)).toBe("00:00:00");
  });

  test("pass 5 seconds return 00:00:05", () => {
    expect(humanReadableTime(5)).toBe("00:00:05");
  });

  test("pass 60 seconds return 00:01:00", () => {
    expect(humanReadableTime(60)).toBe("00:01:00");
  });

  test("pass 59 seconds return 00:00:59", () => {
    expect(humanReadableTime(59)).toBe("00:00:59");
  });

  test("pass 86399 seconds return 23:59:59", () => {
    expect(humanReadableTime(86399)).toBe("23:59:59");
  });

  test("pass 359999 seconds return 99:59:59", () => {
    expect(humanReadableTime(359999)).toBe("99:59:59");
  });
});
