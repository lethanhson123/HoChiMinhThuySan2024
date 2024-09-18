import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucVungTrongComponent } from './to-chuc-vung-trong.component';

describe('ToChucVungTrongComponent', () => {
  let component: ToChucVungTrongComponent;
  let fixture: ComponentFixture<ToChucVungTrongComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucVungTrongComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucVungTrongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
