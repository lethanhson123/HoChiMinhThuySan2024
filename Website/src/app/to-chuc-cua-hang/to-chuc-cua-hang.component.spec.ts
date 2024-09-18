import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucCuaHangComponent } from './to-chuc-cua-hang.component';

describe('ToChucCuaHangComponent', () => {
  let component: ToChucCuaHangComponent;
  let fixture: ComponentFixture<ToChucCuaHangComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucCuaHangComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucCuaHangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
