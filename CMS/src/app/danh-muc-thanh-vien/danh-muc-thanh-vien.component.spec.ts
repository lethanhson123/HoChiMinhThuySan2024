import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucThanhVienComponent } from './danh-muc-thanh-vien.component';

describe('DanhMucThanhVienComponent', () => {
  let component: DanhMucThanhVienComponent;
  let fixture: ComponentFixture<DanhMucThanhVienComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucThanhVienComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucThanhVienComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
