import { Injectable } from '@angular/core';
import { MatSelectConfig } from '@angular/material/select';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotifyService {

  constructor(private snackbar:MatSnackBar) { }
  success(message:string,action:string):void{
    let config:MatSnackBarConfig={
      duration:3000,
      panelClass:'primary',
      horizontalPosition:'right',
      verticalPosition:'top'
    }
    this.snackbar.open(message,action,config);
  }
  fail(message:string,action:string):void{
    let config:MatSnackBarConfig={
      duration:3000,
      panelClass:'warn',
      horizontalPosition:'right',
      verticalPosition:'top'
    }
    this.snackbar.open(message,action,config);
  }
}
