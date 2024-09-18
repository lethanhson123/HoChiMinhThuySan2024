import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucNuoiNhuyenTheComponent } from './to-chuc-nuoi-nhuyen-the.component';

describe('ToChucNuoiNhuyenTheComponent', () => {
  let component: ToChucNuoiNhuyenTheComponent;
  let fixture: ComponentFixture<ToChucNuoiNhuyenTheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucNuoiNhuyenTheComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucNuoiNhuyenTheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
