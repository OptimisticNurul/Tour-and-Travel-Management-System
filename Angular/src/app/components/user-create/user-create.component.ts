import { Component } from '@angular/core';
import { UserVM } from '../../models/user-vm';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataService } from '../../services/data.service';
import { NotifyService } from '../../services/notify.service';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent {
  userPicture: File = null!;

  constructor(
    public dataSvc: DataService,
    private route: Router,
    private notifySvc: NotifyService
  ) { }

  userForm: FormGroup = new FormGroup({
    userName: new FormControl(undefined, Validators.required),
    password: new FormControl(undefined, Validators.required),
    email: new FormControl(undefined, Validators.required),
    role: new FormControl(undefined, Validators.required),
    imageFile: new FormControl(undefined)

  });
  onFileSelected(event: any) {
    this.userPicture = event.target.files[0];
  }
  insert() {

    // Continue with form submission, using isoBirthDate instead of birthDate
    var formData = new FormData();
    formData.append("userName", this.userForm.get("userName")?.value);
    formData.append("password", this.userForm.get("password")?.value);
    formData.append("email", this.userForm.get("email")?.value);
    formData.append("role", this.userForm.get("role")?.value);
    formData.append("imageFile", this.userPicture, this.userPicture.name);

    // Send the form data to the backend
    this.dataSvc.insertUser(formData).subscribe({
      next: r => {
        console.log(r);
        this.route.navigate(['/userCreate']);
        this.notifySvc.success("Data inserted successfully !!", "DISMISS");
        this.userForm.reset({});
      }, error: err => {
        console.log(err);
      }
    });
  }
}