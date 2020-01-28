import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-decision-wizard',
  templateUrl: './decision-wizard.component.html',
  styleUrls: ['./decision-wizard.component.scss']
})
export class DecisionWizardComponent implements OnInit {
  showNext: any;
  catName: string;

  constructor() {}

  ngOnInit() {}

  selectPath(catName: string) {
    this.showNext.active = !this.showNext.active;
  }
}
