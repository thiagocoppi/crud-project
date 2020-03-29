import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarEditarFornecedoresComponent } from './cadastrar-editar-fornecedores.component';

describe('CadastrarEditarFornecedoresComponent', () => {
  let component: CadastrarEditarFornecedoresComponent;
  let fixture: ComponentFixture<CadastrarEditarFornecedoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastrarEditarFornecedoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastrarEditarFornecedoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
