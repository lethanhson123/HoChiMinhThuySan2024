import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Upload009Component } from './upload009.component';

describe('Upload009Component', () => {
  let component: Upload009Component;
  let fixture: ComponentFixture<Upload009Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Upload009Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Upload009Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
