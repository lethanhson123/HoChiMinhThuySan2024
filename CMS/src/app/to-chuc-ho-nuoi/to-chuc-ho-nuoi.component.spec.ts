import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucHoNuoiComponent } from './to-chuc-ho-nuoi.component';

describe('ToChucHoNuoiComponent', () => {
  let component: ToChucHoNuoiComponent;
  let fixture: ComponentFixture<ToChucHoNuoiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucHoNuoiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucHoNuoiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
