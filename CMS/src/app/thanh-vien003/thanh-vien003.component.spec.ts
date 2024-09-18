import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThanhVien003Component } from './thanh-vien003.component';

describe('ThanhVien003Component', () => {
  let component: ThanhVien003Component;
  let fixture: ComponentFixture<ThanhVien003Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThanhVien003Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThanhVien003Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
