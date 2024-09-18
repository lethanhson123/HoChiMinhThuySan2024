import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BanDo003Component } from './ban-do003.component';

describe('BanDo003Component', () => {
  let component: BanDo003Component;
  let fixture: ComponentFixture<BanDo003Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BanDo003Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BanDo003Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
