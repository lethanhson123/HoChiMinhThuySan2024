import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThanhVienDetail001Component } from './thanh-vien-detail001.component';

describe('ThanhVienDetail001Component', () => {
  let component: ThanhVienDetail001Component;
  let fixture: ComponentFixture<ThanhVienDetail001Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThanhVienDetail001Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThanhVienDetail001Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
