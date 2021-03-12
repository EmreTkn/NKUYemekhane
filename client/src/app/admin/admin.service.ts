import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IMenu } from '../shared/models/menu';
import { MenuParams } from '../shared/models/menuParams';
import { Scholl } from '../shared/models/scholl';
import { UpdateParam } from '../shared/models/update';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  baseUrl=environment.apiUrl;
  params=new MenuParams();
  private adminParamsSource=new BehaviorSubject<MenuParams>(this.params);
  adminParams$=this.adminParamsSource.asObservable();

  constructor(private http:HttpClient) { }

  getMenusByDate(){
    let params=new HttpParams();

    params=params.append('month',this.getCurrentParams().month.toString());
    params=params.append('year',this.getCurrentParams().year.toString());
    params=params.append('schoolNameId',this.getCurrentParams().schoolNameId.toString());
    params=params.append('dinnerTimeId',this.getCurrentParams().dinnerTimeId.toString());

    return this.http.get<IMenu>(this.baseUrl+'menu/getall',{observe:'response',params}).pipe(
      map((res)=>{
        return res.body;
      })
    );
  }
  getCurrentParams(){
    return this.adminParamsSource.value;
  }

  updateMenus(param:UpdateParam){
    console.log(param.id);
    return this.http.post(this.baseUrl + 'admin' ,param);
  }
}
