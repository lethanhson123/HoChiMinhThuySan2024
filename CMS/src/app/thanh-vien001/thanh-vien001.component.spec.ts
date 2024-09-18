import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThanhVien001Component } from './thanh-vien001.component';

describe('ThanhVien001Component', () => {
  let component: ThanhVien001Component;
  let fixture: ComponentFixture<ThanhVien001Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThanhVien001Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThanhVien001Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
