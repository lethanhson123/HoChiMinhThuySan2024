import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BanDo007Component } from './ban-do007.component';

describe('BanDo007Component', () => {
  let component: BanDo007Component;
  let fixture: ComponentFixture<BanDo007Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BanDo007Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BanDo007Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
