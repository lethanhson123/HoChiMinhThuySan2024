import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Upload002Component } from './upload002.component';

describe('Upload002Component', () => {
  let component: Upload002Component;
  let fixture: ComponentFixture<Upload002Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Upload002Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Upload002Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
