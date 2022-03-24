import { deepestLeavesSum } from "./deepest-leaves-sum";
import { makeTree } from "../../helpers/tree-node";

describe("deepest leaves sum", () => {
  it("example 1", () => {
    const tree = makeTree([1, 2, 3, 4, 5, null, 6, 7, null, null, null, null, 8]);
    expect(deepestLeavesSum(tree)).toEqual(15);
  });

  it("example 2", () => {
    const tree = makeTree([6, 7, 8, 2, 7, 1, 3, 9, null, 1, 4, null, null, null, 5]);
    expect(deepestLeavesSum(tree)).toEqual(19);
  });
});
