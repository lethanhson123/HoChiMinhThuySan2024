import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucLoaiHinhComponent } from './danh-muc-loai-hinh.component';

describe('DanhMucLoaiHinhComponent', () => {
  let component: DanhMucLoaiHinhComponent;
  let fixture: ComponentFixture<DanhMucLoaiHinhComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucLoaiHinhComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucLoaiHinhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
