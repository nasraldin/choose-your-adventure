import {
  HttpClientTestingModule,
  HttpTestingController
} from '@angular/common/http/testing';
import { TestBed, inject } from '@angular/core/testing';

import { TreeNodeService } from './tree-node.service';

const mockTreeNodes = {
  treeNodes: [
    {
      id: 1,
      question: 'string',
      parentId: 'number'
    }
  ]
};

describe('Service: TreeNodeService', () => {
  let httpMock: HttpTestingController;
  let service: TreeNodeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TreeNodeService]
    });
  });

  beforeEach(inject(
    [TreeNodeService, HttpTestingController],
    (service$, httpMock$) => {
      service = service$;
      httpMock = httpMock$;
    }
  ));

  it('getTreeNodes: should return a TreeNodes list', () => {
    const expected = [
      {
        id: 1,
        question: 'string',
        parentId: 'number'
      }
    ];
    service.getTreeNodes({ id: 1 }).subscribe(treeNode => {
      expect(treeNode).toEqual(expect.arrayContaining(expected));
      expect(treeNode[0][0]).toBe('GetByCategoryId');
    });

    const req = httpMock.expectOne('/api/TreeNode/GetByCategoryId');

    req.flush(mockTreeNodes);
    httpMock.verify();
  });
});
