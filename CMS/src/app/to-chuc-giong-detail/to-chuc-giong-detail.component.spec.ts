import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucGiongDetailComponent } from './to-chuc-giong-detail.component';

describe('ToChucGiongDetailComponent', () => {
  let component: ToChucGiongDetailComponent;
  let fixture: ComponentFixture<ToChucGiongDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucGiongDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucGiongDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
