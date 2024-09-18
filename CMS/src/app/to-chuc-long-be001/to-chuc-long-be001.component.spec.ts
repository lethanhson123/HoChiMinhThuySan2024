import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucLongBe001Component } from './to-chuc-long-be001.component';

describe('ToChucLongBe001Component', () => {
  let component: ToChucLongBe001Component;
  let fixture: ComponentFixture<ToChucLongBe001Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucLongBe001Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucLongBe001Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
