import { TreeNode } from "../../helpers/tree-node";

export const deepestLeavesSum = (root: TreeNode | null): number => {
  let queue: (TreeNode | null)[] = [];
  queue.push(root);
  let levelSum = 0;

  while (queue.length !== 0) {
    levelSum = 0;
    let size = queue.length;
    for (let i = 0; i < size; i++) {
      const cur = queue.shift()!;
      levelSum += cur.val;
      if (cur.left !== null) queue.push(cur.left);
      if (cur.right !== null) queue.push(cur.right);
    }
  }

  return levelSum;
};
