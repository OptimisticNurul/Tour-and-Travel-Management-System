import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { DataService } from '../../services/data.service';
import { NotifyService } from '../../services/notify.service';
import { MatDialog } from '@angular/material/dialog';
import { TourVM } from '../../models/tour-vm'; 
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-tour',
  templateUrl: './tour.component.html',
  styleUrls: ['./tour.component.css']
})
export class TourComponent implements OnInit {
  tourVM: TourVM[] = [];
  dataSource: MatTableDataSource<TourVM> = new MatTableDataSource(this.tourVM);

 // @ViewChild(MatSort) sort: MatSort;
 // @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns: string[] = ['tourName', 'destination', 'duration', 'departureTime', 'arrivalTime', 'availableSlots',];

  constructor(
    private dataSvc: DataService,
    private notifySVC: NotifyService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.LoadTours();
  }
  LoadTours(){
    this.dataSvc.getTours().subscribe(result=>{
      this.tourVM=result;
      console.log(result);
    },err=>{
      this.notifySVC.fail("Failed To Load Data","DISMISS");
    })
  }

  confirmDelete(item: TourVM) {
    this.dialog.open(ConfirmDialogComponent, {
      width: '550px'
    }).afterClosed().subscribe(r => {
      if (r) {
        this.dataSvc.deleteTour(Number(item.tourId))
        .subscribe(x => {
          this.notifySVC.success("successfully Deleted!!", "DISMISS");
          this.LoadTours();
        }, err => {
          this.notifySVC.fail("successfully Deleted!!!","DISMISS");
          this.LoadTours();
        });
      }
    });
  }
}