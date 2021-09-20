import hashTagGenerator from "./hashtag-generator";

describe("hash tag generator tests", () => {

    test("expected an empty string to return false", () => {
        expect(hashTagGenerator("")).toBeFalsy();
    });

    test("still an empty string", () => {
        expect(hashTagGenerator(" ".repeat(200))).toBeFalsy();
    });

    test("expected a Hashtag (#) at the beginning", () => {
        expect(hashTagGenerator("Do We have A Hashtag")).toBe("#DoWeHaveAHashtag");
    });

    test("should handle a single word", () => {
        expect(hashTagGenerator("Codewars")).toBe("#Codewars");
    });

    test("should remove spaces", () => {
        expect(hashTagGenerator("Codewars Is Nice")).toBe("#CodewarsIsNice");
    });

    test("should capitalize first letters of words", () => {
        expect(hashTagGenerator("Codewars is nice")).toBe("#CodewarsIsNice");
    });

    test("should remove spaces between words", () => {
        expect(hashTagGenerator(`code${" ".repeat(140)}wars`)).toBe("#CodeWars");
    });

    test("should return false if the final word is longer than 140 chars", () => {
        expect(hashTagGenerator(`L${"o".repeat(155)}ng Cat`)).toBeFalsy();
    });

    test("should work with repeating letters", () => {
        expect(hashTagGenerator("a".repeat(139))).toBe(`#A${"a".repeat(138)}`);
    });

    test("should return false with repeating letters if length more then 140 chars", () => {
        expect(hashTagGenerator("a".repeat(140))).toBeFalsy();
    });
});