import { AppConfigService } from './app-config.service';
import {
  HttpTestingController,
  HttpClientTestingModule
} from '@angular/common/http/testing';
import { TestBed, inject } from '@angular/core/testing';

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

  it('should be created', inject([AppConfigService], () => {
    expect(service).toBeTruthy();
  }));

  // it('load() should return value from a promise', done => {
  //   service.load().then(value => {
  //     expect(value).toBe({});
  //     done();
  //   });
  // });
});
