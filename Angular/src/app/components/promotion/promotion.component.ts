import { Component, ViewChild } from '@angular/core';
import { Promotion } from '../../models/promotion';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { DataService } from '../../services/data.service';
import { NotifyService } from '../../services/notify.service';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-promotion',
  templateUrl: './promotion.component.html',
  styleUrl: './promotion.component.css'
})
export class PromotionComponent {
  promotions:Promotion[]=[];
  dataSource:MatTableDataSource<Promotion>=new MatTableDataSource(this.promotions);
  
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;

  columnList:string[]=["promoCode","description","discount","startDate","endDate","remainingUses","actions"];

  constructor(
    private dataSvc:DataService,
    private notifySVC:NotifyService,
    private dialog:MatDialog
  ){}

  ngOnInit():void{
    this.dataSvc.getPromotions().subscribe(x=>{
      this.promotions=x;
      console.log(x);
      this.dataSource.data=this.promotions;

      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }, err=>{
      this.notifySVC.fail("Fail To Load Promotion!!","Dismiss");
    })
  }

  confirmDelete(item: Promotion) {
    this.dialog.open(ConfirmDialogComponent, {
      width: '550px'
    }).afterClosed().subscribe(r => {
      if (r) this.dataSvc.deletePromotion(Number(item.promotionId))
        .subscribe(x => {
          this.notifySVC.success("successfully Deleted!!", "DISMISS");
          this.dataSource.data = this.dataSource.data.filter(d => d.promotionId != x.promotionId);
        }, err => {
          this.notifySVC.fail("Data delete failed!!!","DISMISS");
        })
    })
  }
}
