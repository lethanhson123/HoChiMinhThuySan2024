import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucTinhThanhToaDoDetailComponent } from './danh-muc-tinh-thanh-toa-do-detail.component';

describe('DanhMucTinhThanhToaDoDetailComponent', () => {
  let component: DanhMucTinhThanhToaDoDetailComponent;
  let fixture: ComponentFixture<DanhMucTinhThanhToaDoDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucTinhThanhToaDoDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucTinhThanhToaDoDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
