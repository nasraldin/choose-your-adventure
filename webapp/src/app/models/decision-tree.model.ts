import { TreeNode } from './tree-node.model';

export interface DecisionTree {
  id: number;
  treeNodes: TreeNode[];
  suggestedNotes: string;
  categoryName: string;
  isDone: boolean;
}
