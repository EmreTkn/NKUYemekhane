import { Component, OnInit } from '@angular/core';
import { BasketService } from '../basket/basket.service';
import { Basket } from '../shared/models/basket';
import { IMenu } from '../shared/models/menu';
import { Scholl } from '../shared/models/scholl';
import { StudentService } from './student.service';


@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {

  menus: IMenu[];
  scholl:Scholl;

  constructor(private studentService: StudentService,private basketService:BasketService) { }

  ngOnInit(): void {
    this.onFirsLogin();
    this.getSchoolName();
  }
  getMenus() {

    this.studentService.getAllMenu().subscribe((response) => {
      if (response) {
        this.menus = response;
      }
    }, error => { console.log(error) });
  }

  onNightgSelected(id: number) {
    this.studentService.menuParams$.subscribe((res) => {
      res.dinnerTimeId = id;
    });
    this.getMenus();
  }

  onMorningSelected(id: number) {
    this.studentService.menuParams$.subscribe((res) => {
      res.dinnerTimeId = id;
    });
    this.getMenus();
  }
  onSchoolSelected(id:number) {
    this.studentService.menuParams$.subscribe((res)=>{
      res.schoolNameId=id;
    });
    this.getMenus();
  }
  onFirsLogin() {
    this.studentService.firstLoginMenuParams().subscribe(() => {
      this.studentService.getAllMenu().subscribe((res) => {
        if (res) {
          this.menus = res;
        }
      })
    });
  }

  getSchoolName(){
    this.studentService.getSchoolNames().subscribe((res)=>{
      if (res) {
        this.scholl=res;
      }
    })
  }

  addItemToBasket(menu:IMenu){
    this.basketService.addItemToBasket(menu);
  }
}
