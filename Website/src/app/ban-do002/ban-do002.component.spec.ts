import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BanDo002Component } from './ban-do002.component';

describe('BanDo002Component', () => {
  let component: BanDo002Component;
  let fixture: ComponentFixture<BanDo002Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BanDo002Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BanDo002Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
