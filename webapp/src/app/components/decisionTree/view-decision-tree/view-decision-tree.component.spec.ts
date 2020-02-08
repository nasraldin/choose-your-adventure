import { TestBed, async } from '@angular/core/testing';

import { DecisionTreeService } from 'src/app/services/decision-tree.service';
import { HttpClientModule } from '@angular/common/http';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { RouterTestingModule } from '@angular/router/testing';
import { ViewDecisionTreeComponent } from './view-decision-tree.component';

describe('ViewDecisionTreeComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule, HttpClientModule],
      declarations: [ViewDecisionTreeComponent],
      providers: [DecisionTreeService],
      schemas: [NO_ERRORS_SCHEMA]
    }).compileComponents();
  }));

  it('should create component', () => {
    const fixture = TestBed.createComponent(ViewDecisionTreeComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });
});
