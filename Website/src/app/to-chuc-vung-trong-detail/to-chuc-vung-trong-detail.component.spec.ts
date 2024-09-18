import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucVungTrongDetailComponent } from './to-chuc-vung-trong-detail.component';

describe('ToChucVungTrongDetailComponent', () => {
  let component: ToChucVungTrongDetailComponent;
  let fixture: ComponentFixture<ToChucVungTrongDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucVungTrongDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucVungTrongDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
