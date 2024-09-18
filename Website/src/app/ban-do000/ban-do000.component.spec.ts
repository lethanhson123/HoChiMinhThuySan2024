import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BanDo000Component } from './ban-do000.component';

describe('BanDo000Component', () => {
  let component: BanDo000Component;
  let fixture: ComponentFixture<BanDo000Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BanDo000Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BanDo000Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
