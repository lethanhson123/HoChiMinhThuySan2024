import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThanhVienLichSuTruyCapComponent } from './thanh-vien-lich-su-truy-cap.component';

describe('ThanhVienLichSuTruyCapComponent', () => {
  let component: ThanhVienLichSuTruyCapComponent;
  let fixture: ComponentFixture<ThanhVienLichSuTruyCapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThanhVienLichSuTruyCapComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThanhVienLichSuTruyCapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
