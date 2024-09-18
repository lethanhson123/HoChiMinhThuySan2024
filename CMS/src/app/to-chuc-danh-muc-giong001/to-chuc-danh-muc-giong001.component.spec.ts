import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucDanhMucGiong001Component } from './to-chuc-danh-muc-giong001.component';

describe('ToChucDanhMucGiong001Component', () => {
  let component: ToChucDanhMucGiong001Component;
  let fixture: ComponentFixture<ToChucDanhMucGiong001Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucDanhMucGiong001Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucDanhMucGiong001Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
