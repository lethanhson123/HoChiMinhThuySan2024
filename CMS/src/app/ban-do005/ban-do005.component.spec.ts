import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BanDo005Component } from './ban-do005.component';

describe('BanDo005Component', () => {
  let component: BanDo005Component;
  let fixture: ComponentFixture<BanDo005Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BanDo005Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BanDo005Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
