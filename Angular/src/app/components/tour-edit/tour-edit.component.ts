import { Component } from '@angular/core';
import { TourVM } from '../../models/tour-vm';
import { DataService } from '../../services/data.service';
import { NotifyService } from '../../services/notify.service';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TourAvailability } from '../../models/tour-availability';

@Component({
  selector: 'app-tour-edit',
  templateUrl: './tour-edit.component.html',
  styleUrl: './tour-edit.component.css'
})
export class TourEditComponent {
  tourVM!:TourVM;
  
  files: File[] = [];
  selectedFile: File | null = null;

  onFileSelected(event: any): void {
    const selectedFiles = event.target.files;
    this.files = Array.from(selectedFiles);
  }

  onFileChange(event: any): void {
    this.selectedFile = event.target.value;
    console.log('Selected file:', this.selectedFile);
  }

  constructor(
    private dataSvc:DataService,
    private notifySvc:NotifyService,
    private activatedRoute:ActivatedRoute,
    private datPipe:DatePipe
  ){}

  tourForm:FormGroup=new FormGroup({
    tourName:new FormControl(undefined,Validators.required),
    destination:new FormControl(undefined,Validators.required),
    duration:new FormControl(undefined,Validators.required),
    departureTime:new FormControl(undefined,Validators.required),
    arrivalTime:new FormControl(undefined,Validators.required),
    description:new FormControl(undefined,Validators.required),
    tourPackageId:new FormControl(undefined,Validators.required),
    date:new FormControl(undefined,Validators.required),
    availableSlots:new FormControl(undefined,Validators.required),
    imageFile: new FormControl(undefined)
  });

  insert(){

  }

  ngOnInit():void{
    let id:number=this.activatedRoute.snapshot.params['id'];
    this.dataSvc.getTourById(id)
    .subscribe(x=>{
      this.tourVM=x;
      this.tourForm.patchValue(this.tourVM);
    },err=>{
      this.notifySvc.fail("Fail to Load Data","DISMISS");
    })
  }

}
