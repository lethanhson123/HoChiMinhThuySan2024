import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucPhuongTienKhaiThacDetailComponent } from './to-chuc-phuong-tien-khai-thac-detail.component';

describe('ToChucPhuongTienKhaiThacDetailComponent', () => {
  let component: ToChucPhuongTienKhaiThacDetailComponent;
  let fixture: ComponentFixture<ToChucPhuongTienKhaiThacDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucPhuongTienKhaiThacDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucPhuongTienKhaiThacDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
