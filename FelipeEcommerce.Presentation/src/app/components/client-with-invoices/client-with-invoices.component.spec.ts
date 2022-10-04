import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientWithInvoicesComponent } from './client-with-invoices.component';

describe('ClientWithInvoicesComponent', () => {
  let component: ClientWithInvoicesComponent;
  let fixture: ComponentFixture<ClientWithInvoicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientWithInvoicesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientWithInvoicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
