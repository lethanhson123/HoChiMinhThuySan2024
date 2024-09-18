import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BanDo006Component } from './ban-do006.component';

describe('BanDo006Component', () => {
  let component: BanDo006Component;
  let fixture: ComponentFixture<BanDo006Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BanDo006Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BanDo006Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
