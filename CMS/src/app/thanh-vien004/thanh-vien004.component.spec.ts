import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThanhVien004Component } from './thanh-vien004.component';

describe('ThanhVien004Component', () => {
  let component: ThanhVien004Component;
  let fixture: ComponentFixture<ThanhVien004Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThanhVien004Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThanhVien004Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
