import { Component } from '@angular/core';
import { UserVM } from '../../models/user-vm';
import { DataService } from '../../services/data.service';
import { NotifyService } from '../../services/notify.service';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {
  userVM:UserVM[]=[];
  dataSource:MatTableDataSource<UserVM>=new MatTableDataSource(this.userVM);

  columnList:string[]=["userName","email","role","profileImage","actions"];

  constructor(
    private dataSvc:DataService,
    private notifySVC:NotifyService,
    private dialog:MatDialog
  ){}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.dataSvc.getUsers().subscribe(users => {
      this.userVM = users;
    });
  }
}
