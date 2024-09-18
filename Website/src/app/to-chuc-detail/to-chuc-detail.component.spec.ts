import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucDetailComponent } from './to-chuc-detail.component';

describe('ToChucDetailComponent', () => {
  let component: ToChucDetailComponent;
  let fixture: ComponentFixture<ToChucDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
