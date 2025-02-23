import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiscountEditorComponent } from './discount-editor.component';

describe('DiscountEditorComponent', () => {
  let component: DiscountEditorComponent;
  let fixture: ComponentFixture<DiscountEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DiscountEditorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DiscountEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
