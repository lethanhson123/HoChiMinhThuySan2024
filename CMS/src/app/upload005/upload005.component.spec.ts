import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Upload005Component } from './upload005.component';

describe('Upload005Component', () => {
  let component: Upload005Component;
  let fixture: ComponentFixture<Upload005Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Upload005Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Upload005Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
