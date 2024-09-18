import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThongKe000Component } from './thong-ke000.component';

describe('ThongKe000Component', () => {
  let component: ThongKe000Component;
  let fixture: ComponentFixture<ThongKe000Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThongKe000Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThongKe000Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
