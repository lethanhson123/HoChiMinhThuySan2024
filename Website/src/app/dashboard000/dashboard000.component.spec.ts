import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Dashboard000Component } from './dashboard000.component';

describe('Dashboard000Component', () => {
  let component: Dashboard000Component;
  let fixture: ComponentFixture<Dashboard000Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Dashboard000Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Dashboard000Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
