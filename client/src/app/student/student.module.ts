import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentComponent } from './student.component';
import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';
import { StudentRoutingModule } from './student-routing.module';



@NgModule({
  declarations: [StudentComponent],
  imports: [
    CommonModule,
    CoreModule,
    SharedModule,
    StudentRoutingModule
  ]
})
export class StudentModule { }
