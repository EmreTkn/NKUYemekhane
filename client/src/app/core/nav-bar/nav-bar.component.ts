import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/shared/models/basket';
import { IUser } from 'src/app/shared/models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  currentUser$:Observable<IUser>;
  basket$:Observable<IBasket>;

  constructor(private accountService:AccountService,private basketService:BasketService,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.currentUser$=this.accountService.currentUser$;
    this.basket$=this.basketService.basket$;
  }

  logout(){
    this.accountService.logout();
    this.toastr.warning("Başarı ile çıkış yaptınız.");
  }
}
