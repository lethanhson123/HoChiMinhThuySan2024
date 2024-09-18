import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToChucHopTacXaComponent } from './to-chuc-hop-tac-xa.component';

describe('ToChucHopTacXaComponent', () => {
  let component: ToChucHopTacXaComponent;
  let fixture: ComponentFixture<ToChucHopTacXaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToChucHopTacXaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToChucHopTacXaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
