import { Component } from '@angular/core';
import { Promotion } from '../../models/promotion';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataService } from '../../services/data.service';
import { NotifyService } from '../../services/notify.service';
import { DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-promotion-edit',
  templateUrl: './promotion-edit.component.html',
  styleUrl: './promotion-edit.component.css'
})
export class PromotionEditComponent {
  promotion!:Promotion;

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
    private activatedRoute:ActivatedRoute,
    private datPipe:DatePipe
  ){}

  get f(){
    return this.promotionForm.controls;
  }

  update(){
    if(this.promotionForm.invalid) return;

    this.promotion.code=this.f['code'].value;
    this.promotion.description=this.f['description'].value;
    this.promotion.discount=this.f['discount'].value;
    this.promotion.startDate=this.f['startDate'].value;
    this.promotion.endDate=this.f['endDate'].value;
    this.promotion.remainingUses=this.f['remainingUses'].value;
    this.promotion.startDate=new Date(<string>this.datPipe.transform(this.promotion.startDate,"yyyy-MM-dd"));
    this.promotion.endDate=new Date(<string>this.datPipe.transform(this.promotion.endDate,"yyyy-MM-dd"));
    this.dataSvc.updatePromotion(this.promotion).subscribe(r=>{
      this.notifySvc.success("Data Updated Successfully","DISMISS");
      this.promotionForm.reset({});
    },err=>{
      this.notifySvc.fail("Failed To Update Data!!","DISMISS");
    })
  }

  ngOnInit():void{
    let id:number=this.activatedRoute.snapshot.params['id'];
    this.dataSvc.getPromotionById(id)
    .subscribe(x=>{
      this.promotion=x;
      this.promotionForm.patchValue(this.promotion);
    },err=>{
      this.notifySvc.fail("Fail to Load Data","DISMISS");
    })
  }
}
