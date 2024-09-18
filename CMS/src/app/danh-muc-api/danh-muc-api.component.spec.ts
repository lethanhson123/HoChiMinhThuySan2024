import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhMucAPIComponent } from './danh-muc-api.component';

describe('DanhMucAPIComponent', () => {
  let component: DanhMucAPIComponent;
  let fixture: ComponentFixture<DanhMucAPIComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DanhMucAPIComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhMucAPIComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
