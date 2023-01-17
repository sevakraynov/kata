import { reverse } from "./reverse-integer";

describe("reverse-integer", () => {
  test.each`
    input   | expected
    ${123}  | ${321}
    ${-123} | ${-321}
    ${120}  | ${21}
  `("returns $expected when $input passed to function", ({ input, expected }) => {
    expect(reverse(input)).toEqual(expected);
  });
});
