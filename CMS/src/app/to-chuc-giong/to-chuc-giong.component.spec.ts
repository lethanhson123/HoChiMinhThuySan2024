import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucGiongComponent } from './to-chuc-giong.component';

describe('ToChucGiongComponent', () => {
  let component: ToChucGiongComponent;
  let fixture: ComponentFixture<ToChucGiongComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucGiongComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucGiongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
