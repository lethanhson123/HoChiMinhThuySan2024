import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChiTieuMoiTruongDetailComponent } from './chi-tieu-moi-truong-detail.component';

describe('ChiTieuMoiTruongDetailComponent', () => {
  let component: ChiTieuMoiTruongDetailComponent;
  let fixture: ComponentFixture<ChiTieuMoiTruongDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChiTieuMoiTruongDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChiTieuMoiTruongDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
