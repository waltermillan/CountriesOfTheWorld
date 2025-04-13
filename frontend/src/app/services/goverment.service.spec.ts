import { TestBed } from '@angular/core/testing';

import { GovermentService } from './goverment.service';

describe('GovermentService', () => {
  let service: GovermentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GovermentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
