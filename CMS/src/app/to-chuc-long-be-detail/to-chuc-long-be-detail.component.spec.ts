import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucLongBeDetailComponent } from './to-chuc-long-be-detail.component';

describe('ToChucLongBeDetailComponent', () => {
  let component: ToChucLongBeDetailComponent;
  let fixture: ComponentFixture<ToChucLongBeDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucLongBeDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucLongBeDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
