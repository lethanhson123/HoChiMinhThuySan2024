import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucTinhThanhToaDoDetail001Component } from './danh-muc-tinh-thanh-toa-do-detail001.component';

describe('DanhMucTinhThanhToaDoDetail001Component', () => {
  let component: DanhMucTinhThanhToaDoDetail001Component;
  let fixture: ComponentFixture<DanhMucTinhThanhToaDoDetail001Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucTinhThanhToaDoDetail001Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucTinhThanhToaDoDetail001Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
