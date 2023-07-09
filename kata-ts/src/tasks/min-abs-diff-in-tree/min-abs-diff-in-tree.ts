import { TreeNode } from "../../helpers/tree-node";

export const getMinimumDifference = (root: TreeNode | null): number => {
  let queue: number[] = [];

  const inOrder = (node: TreeNode | null): void => {
    if (node === null) {
      return;
    }

    inOrder(node.left);
    queue.push(node.val);
    inOrder(node.right);
  };

  inOrder(root);

  let min = Number.MAX_VALUE;

  for (let index = 1; index < queue.length; index++) {
    let diff = queue[index] - queue[index - 1];
    if(diff < min) {
      min = diff;
    }
  }

  return min;
}
