import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { threadId } from 'node:worker_threads';
import { IMenu } from '../shared/models/menu';
import { MenuParams } from '../shared/models/menuParams';
import { Scholl } from '../shared/models/scholl';
import { UpdateParam } from '../shared/models/update';
import { StudentService } from '../student/student.service';
import { AdminService } from './admin.service';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  constructor(private adminService: AdminService, private fb: FormBuilder, private studentService: StudentService) { }

  menus: IMenu;
  paramsForm: FormGroup;
  menuForm: FormGroup;
  month = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
  year = [2021, 2022, 2023, 2024, 2025, 2026];
  dinnerTime = [
    { name: "Öğlen", id: 1 },
    { name: "Akşam", id: 2 }
  ];
  scholl: Scholl;

  ngOnInit(): void {
    this.createParamsForm();
    this.createMenuForm();
    this.getSchools();
  }

  getMenusByDate(params: MenuParams) {
    this.adminService.adminParams$.subscribe((res) => {
      res.month = params.month;
      res.year = params.year;
      res.dinnerTimeId = params.dinnerTimeId;
      res.schoolNameId = params.schoolNameId;
    });
    this.getMenus();
  }
  onSchoolSelected(id: number) {
    console.log(id);
    this.adminService.adminParams$.subscribe((res) => {
      res.schoolNameId = id;
    });
  }

  onDinnerSelected(id: number) {
    this.adminService.adminParams$.subscribe((res) => {
      res.dinnerTimeId = id;
    });
  }

  onMonthSelected(id: number) {
    this.adminService.adminParams$.subscribe((res) => {
      res.month = id;
    });
  }

  onYearSelected(id: number) {
    this.adminService.adminParams$.subscribe((res) => {
      res.year = id;
    })
  }

  getMenus() {
    this.adminService.getMenusByDate().subscribe((res => {
      this.menus = res;
      console.log(this.menus);
    }));
  }

  createParamsForm() {
    this.paramsForm = this.fb.group({
      schoolName: [null, [Validators.required]],
      dinnerTime: [null, [Validators.required]],
      month: [null, [Validators.required]],
      year: [null, [Validators.required]]
    });
  }

  createMenuForm() {
    this.menuForm = this.fb.group({
      foodFirst: [null, [Validators.required]],
      foodSecond: [null, [Validators.required]],
      foodThird: [null, [Validators.required]],
      foodForth: [null, [Validators.required]],
    })
  }

  getSchools() {
    this.studentService.getSchoolNames().subscribe((res) => {
      this.scholl = res;
      console.log(this.scholl);
    });
  }
  onSubmit(id: number) {
    const updateParam = new UpdateParam();
    updateParam.id = id;
    updateParam.foodFirst = this.menuForm.value.foodFirst;
    updateParam.foodSecond = this.menuForm.value.foodSecond;
    updateParam.foodThird = this.menuForm.value.foodThird;
    updateParam.foodFourth = this.menuForm.value.foodForth;
    this.adminService.updateMenus(updateParam).subscribe(()=>{

    });
    console.log(updateParam);
  }
}
