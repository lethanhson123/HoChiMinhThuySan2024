import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Upload007Component } from './upload007.component';

describe('Upload007Component', () => {
  let component: Upload007Component;
  let fixture: ComponentFixture<Upload007Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Upload007Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Upload007Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
