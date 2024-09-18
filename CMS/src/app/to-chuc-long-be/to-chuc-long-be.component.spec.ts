import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucLongBeComponent } from './to-chuc-long-be.component';

describe('ToChucLongBeComponent', () => {
  let component: ToChucLongBeComponent;
  let fixture: ComponentFixture<ToChucLongBeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucLongBeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucLongBeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
