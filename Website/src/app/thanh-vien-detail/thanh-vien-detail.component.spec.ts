import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThanhVienDetailComponent } from './thanh-vien-detail.component';

describe('ThanhVienDetailComponent', () => {
  let component: ThanhVienDetailComponent;
  let fixture: ComponentFixture<ThanhVienDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThanhVienDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThanhVienDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
