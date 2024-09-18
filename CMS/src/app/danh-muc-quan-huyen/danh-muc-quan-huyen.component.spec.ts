import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucQuanHuyenComponent } from './danh-muc-quan-huyen.component';

describe('DanhMucQuanHuyenComponent', () => {
  let component: DanhMucQuanHuyenComponent;
  let fixture: ComponentFixture<DanhMucQuanHuyenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucQuanHuyenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucQuanHuyenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
