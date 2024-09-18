import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucHieuMayComponent } from './danh-muc-hieu-may.component';

describe('DanhMucHieuMayComponent', () => {
  let component: DanhMucHieuMayComponent;
  let fixture: ComponentFixture<DanhMucHieuMayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucHieuMayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucHieuMayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
