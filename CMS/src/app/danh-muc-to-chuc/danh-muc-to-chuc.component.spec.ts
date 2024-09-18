import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucToChucComponent } from './danh-muc-to-chuc.component';

describe('DanhMucToChucComponent', () => {
  let component: DanhMucToChucComponent;
  let fixture: ComponentFixture<DanhMucToChucComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucToChucComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucToChucComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
