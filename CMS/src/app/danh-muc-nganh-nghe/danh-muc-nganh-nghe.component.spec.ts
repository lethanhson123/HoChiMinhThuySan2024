import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucNganhNgheComponent } from './danh-muc-nganh-nghe.component';

describe('DanhMucNganhNgheComponent', () => {
  let component: DanhMucNganhNgheComponent;
  let fixture: ComponentFixture<DanhMucNganhNgheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucNganhNgheComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucNganhNgheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
