import { Component, OnInit } from '@angular/core';

import { Category } from './../../../models/category.model';
import { CategoryService } from './../../../services/category.service';
import { SearchModel } from './../../../models/search.model';
import { TreeNode } from './../../../models/tree-node.model';
import { TreeNodeService } from './../../../services/tree-node.service';

@Component({
  selector: 'app-decision-wizard',
  templateUrl: './decision-wizard.component.html',
  styleUrls: ['./decision-wizard.component.scss']
})
export class DecisionWizardComponent implements OnInit {
  categories: Category[];
  treeNodes: TreeNode[];
  seachFilter: SearchModel = new SearchModel();
  categoryName: string;

  constructor(
    private categoryService: CategoryService,
    private treeNodeService: TreeNodeService
  ) {}

  ngOnInit() {
    this.fetch();
  }

  fetch() {
    this.categoryService.getCategories().subscribe(
      response => {
        if (response && response.length > 0) {
          console.log(response);

          this.categories = response;
        } else {
          console.log('serverError');
        }
      },
      err => {
        console.log(err);
      }
    );
  }

  fetchTreeNodes(categoryId: number, categoryName: string) {
    if (categoryId) {
      this.seachFilter.id = categoryId;
      this.categoryName = categoryName;
      this.treeNodeService.getTreeNodes(this.seachFilter).subscribe(
        response => {
          if (response && response.length > 0) {
            console.log(response);

            this.treeNodes = response;
          } else {
            this.treeNodes = undefined;
            this.categoryName = undefined;
            console.log('serverError');
          }
        },
        err => {
          console.log(err);
        }
      );
    }

    this.treeNodes = undefined;
    this.categoryName = undefined;
  }
}
