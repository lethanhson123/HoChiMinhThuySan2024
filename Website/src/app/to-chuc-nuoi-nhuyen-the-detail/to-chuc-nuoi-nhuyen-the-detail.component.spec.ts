import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucNuoiNhuyenTheDetailComponent } from './to-chuc-nuoi-nhuyen-the-detail.component';

describe('ToChucNuoiNhuyenTheDetailComponent', () => {
  let component: ToChucNuoiNhuyenTheDetailComponent;
  let fixture: ComponentFixture<ToChucNuoiNhuyenTheDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucNuoiNhuyenTheDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucNuoiNhuyenTheDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
