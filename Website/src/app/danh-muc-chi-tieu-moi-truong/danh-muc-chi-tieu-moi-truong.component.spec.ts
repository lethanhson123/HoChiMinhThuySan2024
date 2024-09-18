import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucChiTieuMoiTruongComponent } from './danh-muc-chi-tieu-moi-truong.component';

describe('DanhMucChiTieuMoiTruongComponent', () => {
  let component: DanhMucChiTieuMoiTruongComponent;
  let fixture: ComponentFixture<DanhMucChiTieuMoiTruongComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucChiTieuMoiTruongComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucChiTieuMoiTruongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
