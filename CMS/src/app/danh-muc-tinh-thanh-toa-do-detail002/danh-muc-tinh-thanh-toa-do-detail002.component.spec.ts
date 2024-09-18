import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucTinhThanhToaDoDetail002Component } from './danh-muc-tinh-thanh-toa-do-detail002.component';

describe('DanhMucTinhThanhToaDoDetail002Component', () => {
  let component: DanhMucTinhThanhToaDoDetail002Component;
  let fixture: ComponentFixture<DanhMucTinhThanhToaDoDetail002Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucTinhThanhToaDoDetail002Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucTinhThanhToaDoDetail002Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
