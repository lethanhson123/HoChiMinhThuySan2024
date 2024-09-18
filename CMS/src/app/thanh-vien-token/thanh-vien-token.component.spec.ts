import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThanhVienTokenComponent } from './thanh-vien-token.component';

describe('ThanhVienTokenComponent', () => {
  let component: ThanhVienTokenComponent;
  let fixture: ComponentFixture<ThanhVienTokenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThanhVienTokenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThanhVienTokenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
