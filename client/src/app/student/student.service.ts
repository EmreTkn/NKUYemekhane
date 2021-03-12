import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IMenu } from '../shared/models/menu';
import { MenuParams } from '../shared/models/menuParams';
import { Scholl } from '../shared/models/scholl';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  baseUrl = environment.apiUrl;
  param1 = new MenuParams();
  private currentMenuParamsSource = new BehaviorSubject<MenuParams>(this.param1);
  menuParams$ = this.currentMenuParamsSource.asObservable();


  constructor(private http: HttpClient) { }



  getAllMenu() {
    let params = new HttpParams();

    params = params.append('schoolNameId', this.param1.schoolNameId.toString());
    params = params.append('dinnerTimeId', this.param1.dinnerTimeId.toString());
    params = params.append('month', this.param1.month.toString());
    params = params.append('year', this.param1.year.toString());


    return this.http.get<IMenu[]>(this.baseUrl + 'menu/getall', { observe: 'response', params }).pipe(
      map((response) => {
        return response.body;
      })
    );
  }

  firstLoginMenuParams() {
    return this.http.get<MenuParams>(this.baseUrl + 'account/school').pipe(
      map((res)=>{
        var date= new Date();
        res.month=date.getMonth()+1;
        res.year=date.getFullYear();
        this.currentMenuParamsSource.next(res);
        this.param1=res;
      })
    )
  }

  getSchoolNames(){
    return this.http.get<Scholl>(this.baseUrl+'menu/schoolName').pipe(
      map((res)=>{
        return res;
      })
    )
  }
}
