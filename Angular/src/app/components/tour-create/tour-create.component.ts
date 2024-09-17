import { Component } from '@angular/core';
import { DataService } from '../../services/data.service';
import { NotifyService } from '../../services/notify.service';
import { DatePipe } from '@angular/common';
import { TourVM } from '../../models/tour-vm';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TourAvailability } from '../../models/tour-availability';
import { Router } from '@angular/router';
import { TourImage } from '../../models/tour-image';

@Component({
  selector: 'app-tour-create',
  templateUrl: './tour-create.component.html',
  styleUrl: './tour-create.component.css'
})
export class TourCreateComponent {
  picFile: File=null!;
  tour:TourVM=new TourVM();
  availability:TourAvailability=new TourAvailability();
  images:TourImage=new TourImage();

  constructor(
    private dataSvc:DataService,
    private notifySvc:NotifyService,
    private route: Router,
    private datePipe:DatePipe
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

  onFileSelected(event: any) {
    this.picFile = event.target.files[0];
  }

   insert(){
    if (this.tourForm.invalid) {
      this.notifySvc.fail("Please fill out all required fields correctly.", "DISMISS");
      return;
    }
    
    var formData = new FormData();
    formData.append("tourName", this.tourForm.get("tourName")?.value);
    formData.append("destination", this.tourForm.get("destination")?.value);
    formData.append("duration", this.tourForm.get("duration")?.value);

    const formattedDate1 = this.datePipe.transform(this.tourForm.get("departureTime")?.value, 'yyyy-MM-dd');
    formData.append("departureTime", formattedDate1 ? formattedDate1 : '');
    //formData.append("departureTime", this.tourForm.get("departureTime")?.value);

    const formattedDate2 = this.datePipe.transform(this.tourForm.get("arrivalTime")?.value, 'yyyy-MM-dd');
    formData.append("arrivalTime", formattedDate2 ? formattedDate2 : '');
    //formData.append("arrivalTime", this.tourForm.get("arrivalTime")?.value);

    formData.append("description", this.tourForm.get("description")?.value);
    formData.append("tourPackageId", this.tourForm.get("tourPackageId")?.value);

    const formattedDate = this.datePipe.transform(this.tourForm.get("date")?.value, 'yyyy-MM-dd');
    formData.append("date", formattedDate ? formattedDate : '');
    //formData.append("date", this.tourForm.get("date")?.value);
    formData.append("availableSlots", this.tourForm.get("availableSlots")?.value);
    
    if (this.picFile) {
      formData.append("imageFile", this.picFile, this.picFile.name);
    }
    console.log('Form Data:', formData);
    this.dataSvc.insertTour(formData).subscribe({
      
      next: r => {
        console.log(formData);
        console.log(r);
        this.route.navigate(['/tourCreate']);
        this.notifySvc.success("Data inserted successfully !!", "DISMISS");
        this.tourForm.reset({});
      }, error: err => {
        console.log("hdhd");
      }
    });
 
  }
}
