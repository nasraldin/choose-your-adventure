export interface TreeNode {
  id: number;
  question: string;
  parentId: number;
  parent: TreeNode;
  treeNodes: TreeNode[];
}
