import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucNuoiNhuyenThe001Component } from './to-chuc-nuoi-nhuyen-the001.component';

describe('ToChucNuoiNhuyenThe001Component', () => {
  let component: ToChucNuoiNhuyenThe001Component;
  let fixture: ComponentFixture<ToChucNuoiNhuyenThe001Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucNuoiNhuyenThe001Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucNuoiNhuyenThe001Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
