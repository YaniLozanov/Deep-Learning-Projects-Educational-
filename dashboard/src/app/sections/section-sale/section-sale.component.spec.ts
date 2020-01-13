import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SectionSaleComponent } from './section-sale.component';

describe('SectionSaleComponent', () => {
  let component: SectionSaleComponent;
  let fixture: ComponentFixture<SectionSaleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SectionSaleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SectionSaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
