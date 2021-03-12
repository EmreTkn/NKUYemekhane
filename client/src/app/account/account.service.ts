import { Injectable } from '@angular/core';
import { of, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IUser } from '../shared/models/user';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl=environment.apiUrl;
  private currentUserSource:ReplaySubject<IUser>=new ReplaySubject<IUser>(null);
  currentUser$=this.currentUserSource.asObservable();


  constructor(private http: HttpClient,private router:Router) { }

  loadCurrentUser(token: string) {

    if (token === null) {
      this.currentUserSource.next(null);
      return of(null);
    }

    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get(this.baseUrl + 'account', {headers}).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      })
    );
  }

  login(value:any){
    return this.http.post(this.baseUrl+'account/login',value).pipe(
      map((user:IUser)=>{
        if(user){
          localStorage.setItem('token',user.token);
          this.currentUserSource.next(user);
        }
      })
    );
  }

  register(value:any){
    return this.http.post(this.baseUrl + 'account/register',value).pipe(
      map((user:IUser)=>{
        if(user){
          localStorage.setItem('token',user.token);
          this.currentUserSource.next(user);
        }
      })
    );
  }

  logout(){
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/account/login');
  }

  checkEmailExists(email:string){
    return this.http.get(this.baseUrl + 'account/emailexists?email=' + email);
  }
}
