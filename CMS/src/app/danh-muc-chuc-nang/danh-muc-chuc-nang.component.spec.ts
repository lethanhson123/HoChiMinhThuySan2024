import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucChucNangComponent } from './danh-muc-chuc-nang.component';

describe('DanhMucChucNangComponent', () => {
  let component: DanhMucChucNangComponent;
  let fixture: ComponentFixture<DanhMucChucNangComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucChucNangComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucChucNangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
