import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucHopTacXaDetailComponent } from './to-chuc-hop-tac-xa-detail.component';

describe('ToChucHopTacXaDetailComponent', () => {
  let component: ToChucHopTacXaDetailComponent;
  let fixture: ComponentFixture<ToChucHopTacXaDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucHopTacXaDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucHopTacXaDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
