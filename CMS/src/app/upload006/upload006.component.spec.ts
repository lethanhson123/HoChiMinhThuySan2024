import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Upload006Component } from './upload006.component';

describe('Upload006Component', () => {
  let component: Upload006Component;
  let fixture: ComponentFixture<Upload006Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Upload006Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Upload006Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
