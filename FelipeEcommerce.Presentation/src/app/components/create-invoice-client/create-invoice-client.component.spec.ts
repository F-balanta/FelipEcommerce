import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateInvoiceClientComponent } from './create-invoice-client.component';

describe('CreateInvoiceClientComponent', () => {
  let component: CreateInvoiceClientComponent;
  let fixture: ComponentFixture<CreateInvoiceClientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateInvoiceClientComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateInvoiceClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
