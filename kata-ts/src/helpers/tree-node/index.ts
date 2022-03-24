// Definition for a binary tree node.
export class TreeNode {
  val: number;
  left: TreeNode | null;
  right: TreeNode | null;
  constructor(val?: number, left?: TreeNode | null, right?: TreeNode | null) {
    this.val = val === undefined ? 0 : val;
    this.left = left === undefined ? null : left;
    this.right = right === undefined ? null : right;
  }
}

export const makeTree = (array: (number | null)[]): TreeNode => {
  let root: TreeNode;
  let queue: (TreeNode | null)[] = [];
  let i = 0;
  let t = new TreeNode(array[i]!);

  root = t;
  queue.push(root);
  i++;

  while (queue.length && i < array.length) {
    let currentNode = queue.shift();
    if (currentNode) {
      currentNode.left = array[i] == null ? null : new TreeNode(array[i]!);
      queue.push(currentNode.left);
      i++;

      if (i >= array.length) {
        break;
      }

      currentNode.right = array[i] == null ? null : new TreeNode(array[i]!);
      queue.push(currentNode.right);
      i++;
    }
  }

  return root;
};
