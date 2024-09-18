import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Upload008Component } from './upload008.component';

describe('Upload008Component', () => {
  let component: Upload008Component;
  let fixture: ComponentFixture<Upload008Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Upload008Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Upload008Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
