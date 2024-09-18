import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucHoNuoi001Component } from './to-chuc-ho-nuoi001.component';

describe('ToChucHoNuoi001Component', () => {
  let component: ToChucHoNuoi001Component;
  let fixture: ComponentFixture<ToChucHoNuoi001Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucHoNuoi001Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucHoNuoi001Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
