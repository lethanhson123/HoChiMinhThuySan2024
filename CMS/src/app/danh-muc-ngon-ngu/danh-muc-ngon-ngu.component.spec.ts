import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucNgonNguComponent } from './danh-muc-ngon-ngu.component';

describe('DanhMucNgonNguComponent', () => {
  let component: DanhMucNgonNguComponent;
  let fixture: ComponentFixture<DanhMucNgonNguComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucNgonNguComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucNgonNguComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
