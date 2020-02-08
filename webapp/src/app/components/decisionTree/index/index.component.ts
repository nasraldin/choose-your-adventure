import { Component, OnInit } from '@angular/core';

import { DecisionTree } from './../../../models/decision-tree.model';
import { DecisionTreeService } from 'src/app/services/decision-tree.service';

@Component({
  selector: 'app-decision-tree',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class DecisionTreeComponent implements OnInit {
  model: DecisionTree[];
  serverError = '';
  noSearchResult = false;

  constructor(private service: DecisionTreeService) {}

  ngOnInit() {
    this.fetch();
  }

  fetch() {
    this.service.getDecisionTree().subscribe(
      response => {
        if (response && response.length > 0) {
          console.log(response);

          this.model = response;
        } else {
          this.serverError = 'error';
        }
      },
      err => {
        console.log(err);
      }
    );
  }
}
