import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThongBaoDetailComponent } from './thong-bao-detail.component';

describe('ThongBaoDetailComponent', () => {
  let component: ThongBaoDetailComponent;
  let fixture: ComponentFixture<ThongBaoDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ThongBaoDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ThongBaoDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
