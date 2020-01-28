import { TestBed, async } from '@angular/core/testing';

import { DecisionWizardComponent } from './decision-wizard.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { RouterTestingModule } from '@angular/router/testing';

describe('DecisionWizardComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [DecisionWizardComponent],
      schemas: [NO_ERRORS_SCHEMA]
    }).compileComponents();
  }));

  it('should create the Header', () => {
    const fixture = TestBed.createComponent(DecisionWizardComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });
});
