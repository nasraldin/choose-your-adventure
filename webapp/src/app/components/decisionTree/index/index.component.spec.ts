import { TestBed, async } from '@angular/core/testing';

import { DecisionTreeComponent } from './index.component';
import { DecisionTreeService } from './../../../services/decision-tree.service';
import { HttpClientModule } from '@angular/common/http';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { RouterTestingModule } from '@angular/router/testing';

describe('DecisionTreeComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule, HttpClientModule],
      declarations: [DecisionTreeComponent],
      providers: [DecisionTreeService],
      schemas: [NO_ERRORS_SCHEMA]
    }).compileComponents();
  }));

  it('should render comp and inject service', async () => {
    const fixture = TestBed.createComponent(DecisionTreeComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });
});
