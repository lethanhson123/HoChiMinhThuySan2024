import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucHoNuoiDetailComponent } from './to-chuc-ho-nuoi-detail.component';

describe('ToChucHoNuoiDetailComponent', () => {
  let component: ToChucHoNuoiDetailComponent;
  let fixture: ComponentFixture<ToChucHoNuoiDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucHoNuoiDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucHoNuoiDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
