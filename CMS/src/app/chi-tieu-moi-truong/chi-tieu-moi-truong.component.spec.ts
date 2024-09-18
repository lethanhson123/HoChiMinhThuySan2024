import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChiTieuMoiTruongComponent } from './chi-tieu-moi-truong.component';

describe('ChiTieuMoiTruongComponent', () => {
  let component: ChiTieuMoiTruongComponent;
  let fixture: ComponentFixture<ChiTieuMoiTruongComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChiTieuMoiTruongComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChiTieuMoiTruongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
