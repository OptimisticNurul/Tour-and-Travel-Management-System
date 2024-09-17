import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PromotionEditComponent } from './promotion-edit.component';

describe('PromotionEditComponent', () => {
  let component: PromotionEditComponent;
  let fixture: ComponentFixture<PromotionEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PromotionEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PromotionEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
