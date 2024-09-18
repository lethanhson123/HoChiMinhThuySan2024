import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Upload003Component } from './upload003.component';

describe('Upload003Component', () => {
  let component: Upload003Component;
  let fixture: ComponentFixture<Upload003Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Upload003Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Upload003Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
