import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucTramQuanTracComponent } from './to-chuc-tram-quan-trac.component';

describe('ToChucTramQuanTracComponent', () => {
  let component: ToChucTramQuanTracComponent;
  let fixture: ComponentFixture<ToChucTramQuanTracComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucTramQuanTracComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucTramQuanTracComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
