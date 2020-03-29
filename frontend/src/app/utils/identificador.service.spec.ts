import { TestBed } from '@angular/core/testing';

import { IdentificadorService } from './identificador.service';

describe('IdentificadorService', () => {
  let service: IdentificadorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IdentificadorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
