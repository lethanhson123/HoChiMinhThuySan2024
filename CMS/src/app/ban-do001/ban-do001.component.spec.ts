import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BanDo001Component } from './ban-do001.component';

describe('BanDo001Component', () => {
  let component: BanDo001Component;
  let fixture: ComponentFixture<BanDo001Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BanDo001Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BanDo001Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
