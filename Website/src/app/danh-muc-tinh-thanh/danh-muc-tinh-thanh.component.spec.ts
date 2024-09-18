import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucTinhThanhComponent } from './danh-muc-tinh-thanh.component';

describe('DanhMucTinhThanhComponent', () => {
  let component: DanhMucTinhThanhComponent;
  let fixture: ComponentFixture<DanhMucTinhThanhComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucTinhThanhComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucTinhThanhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
