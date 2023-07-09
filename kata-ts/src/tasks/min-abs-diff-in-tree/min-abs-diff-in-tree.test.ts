import { TreeNode } from "../../helpers/tree-node";
import { getMinimumDifference } from "../min-abs-diff-in-tree/min-abs-diff-in-tree";

const cases: { tree: TreeNode; expected: number }[] = [
  {
    tree: new TreeNode(1, new TreeNode(0), new TreeNode(48, new TreeNode(12), new TreeNode(49))),
    expected: 1,
  },
  {
    tree: new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(6)),
    expected: 1,
  },
];

describe("min-abs-diff-in-tree", () => {
  test.each(cases)("case #%#", ({ tree, expected }) => {
    const result = getMinimumDifference(tree);
    expect(result).toBe(expected);
  });
});
