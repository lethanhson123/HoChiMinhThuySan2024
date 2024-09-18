import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucGiong001Component } from './to-chuc-giong001.component';

describe('ToChucGiong001Component', () => {
  let component: ToChucGiong001Component;
  let fixture: ComponentFixture<ToChucGiong001Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucGiong001Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucGiong001Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
