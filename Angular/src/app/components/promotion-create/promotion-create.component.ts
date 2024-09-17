import { Component } from '@angular/core';
import { Promotion } from '../../models/promotion';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataService } from '../../services/data.service';
import { NotifyService } from '../../services/notify.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-promotion-create',
  templateUrl: './promotion-create.component.html',
  styleUrl: './promotion-create.component.css'
})
export class PromotionCreateComponent {
  promotion:Promotion=new Promotion();

  promotionForm:FormGroup=new FormGroup({
    code:new FormControl('',Validators.required),
    description:new FormControl('',Validators.required),
    discount:new FormControl('',Validators.required),
    startDate:new FormControl('',Validators.required),
    endDate:new FormControl('',Validators.required),
    remainingUses:new FormControl('',Validators.required)
    
  });

  constructor(
    private dataSvc:DataService,
    private notifySvc:NotifyService,
    private datPipe:DatePipe
  ){}

  get f(){
    return this.promotionForm.controls;
  }

  insert(){
    if(this.promotionForm.invalid) return;
    this.promotion.code=this.f['code'].value;
    this.promotion.description=this.f['description'].value;
    this.promotion.discount=this.f['discount'].value;
    this.promotion.startDate=this.f['startDate'].value;
    this.promotion.endDate=this.f['endDate'].value;
    this.promotion.remainingUses=this.f['remainingUses'].value;
    this.promotion.startDate=new Date(<string>this.datPipe.transform(this.promotion.startDate,"yyyy-MM-dd"));
    this.promotion.endDate=new Date(<string>this.datPipe.transform(this.promotion.endDate,"yyyy-MM-dd"));
    this.dataSvc.insertPromotion(this.promotion).subscribe(r=>{
      this.notifySvc.success("Data Inserted Successfully","DISMISS");
      this.promotionForm.reset({});
    },err=>{
      this.notifySvc.fail("Data Inser Fail!!","DISMISS");
    })
  }
}
