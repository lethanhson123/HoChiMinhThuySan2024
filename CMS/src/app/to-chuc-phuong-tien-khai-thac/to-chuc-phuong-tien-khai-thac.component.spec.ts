import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucPhuongTienKhaiThacComponent } from './to-chuc-phuong-tien-khai-thac.component';

describe('ToChucPhuongTienKhaiThacComponent', () => {
  let component: ToChucPhuongTienKhaiThacComponent;
  let fixture: ComponentFixture<ToChucPhuongTienKhaiThacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucPhuongTienKhaiThacComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucPhuongTienKhaiThacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
