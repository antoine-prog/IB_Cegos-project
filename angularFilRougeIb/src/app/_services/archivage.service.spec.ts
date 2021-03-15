import { TestBed } from '@angular/core/testing';

import { ArchivageService } from './archivage.service';

describe('ArchivageService', () => {
  let service: ArchivageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ArchivageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
