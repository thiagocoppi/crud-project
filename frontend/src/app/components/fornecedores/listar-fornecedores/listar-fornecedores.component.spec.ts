import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarFornecedoresComponent } from './listar-fornecedores.component';

describe('ListarFornecedoresComponent', () => {
  let component: ListarFornecedoresComponent;
  let fixture: ComponentFixture<ListarFornecedoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListarFornecedoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarFornecedoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
