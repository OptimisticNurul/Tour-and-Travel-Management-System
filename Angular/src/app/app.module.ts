import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { NavComponent } from './components/nav/nav.component';
import { HomeComponent } from './components/home/home.component';
import { MatModule } from './modules/mat/mat.module';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { PromotionComponent } from './components/promotion/promotion.component';
import { PromotionCreateComponent } from './components/promotion-create/promotion-create.component';
import { PromotionEditComponent } from './components/promotion-edit/promotion-edit.component';
import { DataService } from './services/data.service';
import { NotifyService } from './services/notify.service';
import { DatePipe } from '@angular/common';
import { TourComponent } from './components/tour/tour.component';
import { TourCreateComponent } from './components/tour-create/tour-create.component';
import { TourEditComponent } from './components/tour-edit/tour-edit.component';
import { PackageComponent } from './components/package/package.component';
import { PackageCreateComponent } from './components/package-create/package-create.component';
import { PackageEditComponent } from './components/package-edit/package-edit.component';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { UserComponent } from './components/user/user.component';
import { UserCreateComponent } from './components/user-create/user-create.component';
import { UserEditComponent } from './components/user-edit/user-edit.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    PromotionComponent,
    PromotionCreateComponent,
    PromotionEditComponent,
    TourComponent,
    TourCreateComponent,
    TourEditComponent,
    PackageComponent,
    PackageCreateComponent,
    PackageEditComponent,
    ConfirmDialogComponent,
    UserComponent,
    UserCreateComponent,
    UserEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatModule
  ],
  providers: [
    DataService,
    NotifyService,
    DatePipe,
    provideClientHydration(),
    provideAnimationsAsync(),
    provideHttpClient(withFetch())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
