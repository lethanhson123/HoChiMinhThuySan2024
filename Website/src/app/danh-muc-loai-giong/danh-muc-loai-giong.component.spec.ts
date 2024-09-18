import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucLoaiGiongComponent } from './danh-muc-loai-giong.component';

describe('DanhMucLoaiGiongComponent', () => {
  let component: DanhMucLoaiGiongComponent;
  let fixture: ComponentFixture<DanhMucLoaiGiongComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucLoaiGiongComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucLoaiGiongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
