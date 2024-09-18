import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucPhuongTienKhaiThac001Component } from './to-chuc-phuong-tien-khai-thac001.component';

describe('ToChucPhuongTienKhaiThac001Component', () => {
  let component: ToChucPhuongTienKhaiThac001Component;
  let fixture: ComponentFixture<ToChucPhuongTienKhaiThac001Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucPhuongTienKhaiThac001Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucPhuongTienKhaiThac001Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
