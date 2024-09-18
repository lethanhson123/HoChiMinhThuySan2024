import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThanhVien002Component } from './thanh-vien002.component';

describe('ThanhVien002Component', () => {
  let component: ThanhVien002Component;
  let fixture: ComponentFixture<ThanhVien002Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThanhVien002Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThanhVien002Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
