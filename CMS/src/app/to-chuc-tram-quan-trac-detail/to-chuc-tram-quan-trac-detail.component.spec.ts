import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucTramQuanTracDetailComponent } from './to-chuc-tram-quan-trac-detail.component';

describe('ToChucTramQuanTracDetailComponent', () => {
  let component: ToChucTramQuanTracDetailComponent;
  let fixture: ComponentFixture<ToChucTramQuanTracDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucTramQuanTracDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucTramQuanTracDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
