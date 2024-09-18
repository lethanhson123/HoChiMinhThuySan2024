import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Upload001Component } from './upload001.component';

describe('Upload001Component', () => {
  let component: Upload001Component;
  let fixture: ComponentFixture<Upload001Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Upload001Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Upload001Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
