import rgbToHex from "./rgbToHex";

describe("rgb to hex", () => {
  test("basic tests", () => {
    expect(rgbToHex(255, 255, 255)).toBe("FFFFFF");
    expect(rgbToHex(0, 0, 0)).toBe("000000");
    expect(rgbToHex(148, 0, 211)).toBe("9400D3");
    expect(rgbToHex(173, 255, 47)).toBe("ADFF2F");
  });

  test("advance tests", () => {
    expect(rgbToHex(255, 255, 300)).toBe("FFFFFF");
    expect(rgbToHex(0, 0, -20)).toBe("000000");
    expect(rgbToHex(300, 255, 255)).toBe("FFFFFF");
  });
});
