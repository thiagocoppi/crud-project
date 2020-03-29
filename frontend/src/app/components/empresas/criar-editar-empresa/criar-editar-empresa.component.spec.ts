import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarEditarEmpresaComponent } from './criar-editar-empresa.component';

describe('CriarEditarEmpresaComponent', () => {
  let component: CriarEditarEmpresaComponent;
  let fixture: ComponentFixture<CriarEditarEmpresaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CriarEditarEmpresaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CriarEditarEmpresaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
