import { TestBed } from '@angular/core/testing';

import { DataAccessService } from './dataaccess.service';

describe('DataAccessService', () => {
  let service: DataAccessService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DataAccessService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
