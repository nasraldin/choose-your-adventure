import {
  HttpClientTestingModule,
  HttpTestingController
} from '@angular/common/http/testing';
import { TestBed, inject } from '@angular/core/testing';

import { DecisionTreeService } from './decision-tree.service';

const mockDecisionTree = {
  decisionTree: [
    {
      id: 1,
      treeNodes: [],
      suggestedNotes: 'string',
      categoryName: 'string',
      isDone: true
    }
  ]
};

describe('Service: DecisionTreeService', () => {
  let httpMock: HttpTestingController;
  let service: DecisionTreeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [DecisionTreeService]
    });
  });

  beforeEach(inject(
    [DecisionTreeService, HttpTestingController],
    (service$, httpMock$) => {
      service = service$;
      httpMock = httpMock$;
    }
  ));

  it('getDecisionTree: should return a DecisionTree list', () => {
    const expected = [
      {
        id: 1,
        treeNodes: [],
        suggestedNotes: 'string',
        categoryName: 'string',
        isDone: true
      }
    ];
    service.getDecisionTree().subscribe(categories => {
      expect(categories).toEqual(expect.arrayContaining(expected));
      expect(categories[0][0]).toBe('DecisionTree');
    });

    const req = httpMock.expectOne('/api/DecisionTree');

    req.flush(mockDecisionTree);
    httpMock.verify();
  });
});
