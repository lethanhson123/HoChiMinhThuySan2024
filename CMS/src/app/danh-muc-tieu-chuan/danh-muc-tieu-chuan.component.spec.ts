import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucTieuChuanComponent } from './danh-muc-tieu-chuan.component';

describe('DanhMucTieuChuanComponent', () => {
  let component: DanhMucTieuChuanComponent;
  let fixture: ComponentFixture<DanhMucTieuChuanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucTieuChuanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucTieuChuanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
