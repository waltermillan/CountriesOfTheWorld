import { TestBed } from '@angular/core/testing';

import { AnthemService } from './anthem.service';

describe('AnthemService', () => {
  let service: AnthemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AnthemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
