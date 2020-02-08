import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { DecisionTree } from './../../../models/decision-tree.model';
import { DecisionTreeService } from '../../../services/decision-tree.service';
import { Location } from '@angular/common';
import { SearchModel } from './../../../models/search.model';

@Component({
  selector: 'app-view-decision-tree',
  templateUrl: './view-decision-tree.component.html',
  styleUrls: ['./view-decision-tree.component.scss']
})
export class ViewDecisionTreeComponent implements OnInit {
  id: number;
  model: DecisionTree;
  seachFilter: SearchModel = new SearchModel();

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private service: DecisionTreeService
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.params.id;
    this.fetch();
  }

  fetch() {
    this.seachFilter.id = this.id;

    this.service.getDetails(this.seachFilter).subscribe(
      response => {
        if (response && response !== undefined) {
          console.log(response);

          this.model = response;
        } else {
          console.log('serverError');
        }
      },
      err => {
        console.log(err);
      }
    );
  }

  back() {
    this.location.back();
  }
}
