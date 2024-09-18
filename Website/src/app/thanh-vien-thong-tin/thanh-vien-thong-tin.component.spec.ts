import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThanhVienThongTinComponent } from './thanh-vien-thong-tin.component';

describe('ThanhVienThongTinComponent', () => {
  let component: ThanhVienThongTinComponent;
  let fixture: ComponentFixture<ThanhVienThongTinComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThanhVienThongTinComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThanhVienThongTinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
