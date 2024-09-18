import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DangKyThanhCongComponent } from './dang-ky-thanh-cong.component';

describe('DangKyThanhCongComponent', () => {
  let component: DangKyThanhCongComponent;
  let fixture: ComponentFixture<DangKyThanhCongComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DangKyThanhCongComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DangKyThanhCongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
