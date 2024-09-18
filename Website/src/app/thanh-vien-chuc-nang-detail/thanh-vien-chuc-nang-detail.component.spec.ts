import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThanhVienChucNangDetailComponent } from './thanh-vien-chuc-nang-detail.component';

describe('ThanhVienChucNangDetailComponent', () => {
  let component: ThanhVienChucNangDetailComponent;
  let fixture: ComponentFixture<ThanhVienChucNangDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThanhVienChucNangDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThanhVienChucNangDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
