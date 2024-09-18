import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucXaPhuongComponent } from './danh-muc-xa-phuong.component';

describe('DanhMucXaPhuongComponent', () => {
  let component: DanhMucXaPhuongComponent;
  let fixture: ComponentFixture<DanhMucXaPhuongComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucXaPhuongComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucXaPhuongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
