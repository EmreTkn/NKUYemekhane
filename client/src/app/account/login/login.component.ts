import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { error } from 'protractor';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IUser } from 'src/app/shared/models/user';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm:FormGroup;
  returnUrl:string;

  constructor(private fb:FormBuilder,private accountService:AccountService,private router:Router,private activatedRoute:ActivatedRoute,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.createLoginForm();
    this.returnUrl = this.activatedRoute.snapshot.queryParams.returnUrl || '/student';
  }

  createLoginForm(){
    this.loginForm=this.fb.group({
      email:[null,[Validators.required,
      Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]],
      password:[null,[Validators.required]]
    });
  }

  onSubmit(){
    this.accountService.login(this.loginForm.value).subscribe(()=>{
    this.router.navigateByUrl(this.returnUrl);
    this.toastr.success("Giriş Yaptınız.")
    },error=>{
      console.log(error);
    });

  }
}
