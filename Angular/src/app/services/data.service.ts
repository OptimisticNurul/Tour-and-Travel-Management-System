import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Promotion } from '../models/promotion';
import { TourVM } from '../models/tour-vm';
import { UserVM } from '../models/user-vm';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  //Promotion:
  constructor(private http:HttpClient) { }
  getPromotions():Observable<Promotion[]>{
    return this.http.get<Promotion[]>("http://localhost:5002/api/Promotions");
  }
  insertPromotion(data:Promotion):Observable<Promotion>{
    return this.http.post<Promotion>(`http://localhost:5002/api/Promotions`,data);
  }
  getPromotionById(id:number):Observable<Promotion>{
    return this.http.get<Promotion>(`http://localhost:5002/api/Promotions/${id}`);
  }
  updatePromotion(data:Promotion):Observable<Promotion>{
    return this.http.put<Promotion>(`http://localhost:5002/api/Promotions/${data.promotionId}`,data);
  }
  deletePromotion(id:number):Observable<Promotion>{
    return this.http.delete<Promotion>(`http://localhost:5002/api/Promotions/${id}`);
  }

  //Tour:
  getTours():Observable<TourVM[]>{
    return this.http.get<TourVM[]>("http://localhost:5002/api/Tours");
  }
  insertTour(data: FormData):Observable<TourVM>{
    return this.http.post<TourVM>(`http://localhost:5002/api/Tours`,data);
  }
  getTourById(id:number):Observable<TourVM>{
    return this.http.get<TourVM>(`http://localhost:5002/api/Tours/${id}`);
  }
  updateTour(data:TourVM):Observable<TourVM>{
    return this.http.put<TourVM>(`http://localhost:5002/api/Tours/${data.tourId}`,data);
  }
  deleteTour(id:number):Observable<TourVM>{
    return this.http.delete<TourVM>(`http://localhost:5002/api/Tours/${id}`);
  }
  //user
  getUsers():Observable<UserVM[]>{
    return this.http.get<UserVM[]>("http://localhost:5002/api/Users");
  }

  insertUser(data: FormData): Observable<UserVM> {
    return this.http.post<UserVM>('http://localhost:5002/api/users', data);
  }

  upload(id: number, formData: FormData): Observable<any> {
    return this.http.post(`http://localhost:5002/api/users/${id}/upload`, formData);
  }

  getUserById(id:number):Observable<UserVM>{
    return this.http.get<UserVM>(`http://localhost:5002/api/Users/${id}`);
  }
  updateUser(data:UserVM):Observable<UserVM>{
    return this.http.put<UserVM>(`http://localhost:5002/api/Users/${data.userId}`,data);
  }
  deleteUser(id:number):Observable<UserVM>{
    return this.http.delete<UserVM>(`http://localhost:5002/api/Users/${id}`);
  }
}
