import { Component, Input, OnInit } from '@angular/core';

import { DecisionTreeFormSubmission } from './../../../../models/decision-tree.model';
import { DecisionTreeService } from 'src/app/services/decision-tree.service';
import { Location } from '@angular/common';
import { TreeNode } from './../../../../models/tree-node.model';

@Component({
  selector: 'app-tree-wizard',
  templateUrl: './tree-wizard.component.html',
  styleUrls: ['./tree-wizard.component.scss']
})
export class TreeWizardComponent implements OnInit {
  @Input() categoryName: string;
  @Input() model: TreeNode[];
  treeNodes = [];
  decisionTree: DecisionTreeFormSubmission = new DecisionTreeFormSubmission();

  constructor(
    private service: DecisionTreeService,
    private location: Location
  ) {}

  ngOnInit() {
    console.log(this.model);
  }

  addNode(id: number) {
    if (this.treeNodes.indexOf(id) === -1) {
      this.treeNodes.push(id);
    } else {
      this.treeNodes.splice(this.treeNodes.indexOf(id), 1);
    }
  }

  onComplete() {
    console.log('onComplete');
    this.decisionTree.categoryName = '';
    this.decisionTree.suggestedNotes = 'Suggested Notes 1233654';
    this.decisionTree.treeNodes = this.treeNodes.join(',');

    if (this.decisionTree && this.treeNodes && this.decisionTree.categoryName) {
      this.service.save(this.decisionTree).subscribe(
        response => {
          if (response && response !== undefined) {
            this.location.back();
          } else {
            console.log('serverError');
          }
        },
        err => {
          console.log(err);
        }
      );
    } else {
      alert('Please answer the questions');
    }
  }
}
