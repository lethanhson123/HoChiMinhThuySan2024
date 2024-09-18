import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucToaDoDetailComponent } from './to-chuc-toa-do-detail.component';

describe('ToChucToaDoDetailComponent', () => {
  let component: ToChucToaDoDetailComponent;
  let fixture: ComponentFixture<ToChucToaDoDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucToaDoDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucToaDoDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
