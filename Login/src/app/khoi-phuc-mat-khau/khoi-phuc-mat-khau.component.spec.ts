import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KhoiPhucMatKhauComponent } from './khoi-phuc-mat-khau.component';

describe('KhoiPhucMatKhauComponent', () => {
  let component: KhoiPhucMatKhauComponent;
  let fixture: ComponentFixture<KhoiPhucMatKhauComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KhoiPhucMatKhauComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KhoiPhucMatKhauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
