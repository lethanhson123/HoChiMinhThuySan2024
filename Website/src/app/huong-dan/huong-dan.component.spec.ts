import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HuongDanComponent } from './huong-dan.component';

describe('HuongDanComponent', () => {
  let component: HuongDanComponent;
  let fixture: ComponentFixture<HuongDanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HuongDanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HuongDanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
