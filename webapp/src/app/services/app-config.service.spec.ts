import {
  HttpClientTestingModule,
  HttpTestingController
} from '@angular/common/http/testing';
import { TestBed, inject } from '@angular/core/testing';

import { AppConfigService } from './app-config.service';

describe('Service: AppConfigService', () => {
  let httpMock: HttpTestingController;
  let service: AppConfigService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [AppConfigService]
    });
  });

  beforeEach(inject(
    [AppConfigService, HttpTestingController],
    (service$, httpMock$) => {
      service = service$;
      httpMock = httpMock$;
    }
  ));

  it('should be initializations', inject([AppConfigService], () => {
    expect(service).toBeTruthy();
  }));

  // it('load() should return value from a promise', async done => {
  //   await service.load().then(value => {
  //     expect(value).toBe(value);
  //     done();
  //   });
  // });
});
