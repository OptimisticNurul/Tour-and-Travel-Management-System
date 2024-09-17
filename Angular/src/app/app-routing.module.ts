import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PromotionComponent } from './components/promotion/promotion.component';
import { PromotionCreateComponent } from './components/promotion-create/promotion-create.component';
import { TourComponent } from './components/tour/tour.component';
import { PackageComponent } from './components/package/package.component';
import { PromotionEditComponent } from './components/promotion-edit/promotion-edit.component';
import { UserComponent } from './components/user/user.component';
import { UserCreateComponent } from './components/user-create/user-create.component';
import { TourCreateComponent } from './components/tour-create/tour-create.component';
import { TourEditComponent } from './components/tour-edit/tour-edit.component';

const routes: Routes = [
  {path:'',component:HomeComponent,pathMatch:'full'},
  {path:'home',component:HomeComponent},
  {path:'promotion',component:PromotionComponent},
  {path:'promotionCreate',component:PromotionCreateComponent},
  {path:'promotionEdit/:id',component:PromotionEditComponent},
  {path:'tour',component:TourComponent},
  {path:'tourCreate',component:TourCreateComponent},
  {path:'tourEdit/:id',component:TourEditComponent},
  {path:'package',component:PackageComponent},
  {path:'user',component:UserComponent},
  {path:'userCreate',component:UserCreateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
