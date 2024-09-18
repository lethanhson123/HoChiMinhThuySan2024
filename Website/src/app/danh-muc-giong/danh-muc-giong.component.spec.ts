import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucGiongComponent } from './danh-muc-giong.component';

describe('DanhMucGiongComponent', () => {
  let component: DanhMucGiongComponent;
  let fixture: ComponentFixture<DanhMucGiongComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucGiongComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucGiongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
