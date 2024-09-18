import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucInfoComponent } from './to-chuc-info.component';

describe('ToChucInfoComponent', () => {
  let component: ToChucInfoComponent;
  let fixture: ComponentFixture<ToChucInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
