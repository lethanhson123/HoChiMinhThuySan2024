import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BanDo004Component } from './ban-do004.component';

describe('BanDo004Component', () => {
  let component: BanDo004Component;
  let fixture: ComponentFixture<BanDo004Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BanDo004Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BanDo004Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
