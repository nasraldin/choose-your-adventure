import {
  HttpClientTestingModule,
  HttpTestingController
} from '@angular/common/http/testing';
import { TestBed, inject } from '@angular/core/testing';

import { CategoryService } from './category.service';

const mockCategories = {
  categories: [
    {
      id: 1,
      name: 'Clean Code'
    }
  ]
};

describe('Service: CategoryService', () => {
  let httpMock: HttpTestingController;
  let service: CategoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CategoryService]
    });
  });

  beforeEach(inject(
    [CategoryService, HttpTestingController],
    (service$, httpMock$) => {
      service = service$;
      httpMock = httpMock$;
    }
  ));

  it('getCategories: should return a category list', () => {
    const expected = [
      {
        id: 1,
        name: 'Clean Code'
      }
    ];
    service.getCategories().subscribe(categories => {
      expect(categories).toEqual(expect.arrayContaining(expected));
      expect(categories[0][0]).toBe('categories');
    });

    const req = httpMock.expectOne('/api/Category');

    req.flush(mockCategories);
    httpMock.verify();
  });
});
