import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoRegistersFoundComponent } from './no-registers-found.component';

describe('NoRegistersFoundComponent', () => {
  let component: NoRegistersFoundComponent;
  let fixture: ComponentFixture<NoRegistersFoundComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoRegistersFoundComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoRegistersFoundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
