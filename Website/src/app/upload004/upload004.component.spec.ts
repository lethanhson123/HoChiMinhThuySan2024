import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Upload004Component } from './upload004.component';

describe('Upload004Component', () => {
  let component: Upload004Component;
  let fixture: ComponentFixture<Upload004Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Upload004Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Upload004Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
