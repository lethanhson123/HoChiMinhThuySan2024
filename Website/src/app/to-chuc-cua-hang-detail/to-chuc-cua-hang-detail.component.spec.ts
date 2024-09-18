import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucCuaHangDetailComponent } from './to-chuc-cua-hang-detail.component';

describe('ToChucCuaHangDetailComponent', () => {
  let component: ToChucCuaHangDetailComponent;
  let fixture: ComponentFixture<ToChucCuaHangDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucCuaHangDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucCuaHangDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
