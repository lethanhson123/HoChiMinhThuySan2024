import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucComponent } from './to-chuc.component';

describe('ToChucComponent', () => {
  let component: ToChucComponent;
  let fixture: ComponentFixture<ToChucComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
