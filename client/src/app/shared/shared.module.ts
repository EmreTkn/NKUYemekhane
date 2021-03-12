import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from './text-input/text-input.component';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { StepperComponent } from './components/stepper/stepper.component';
import { BasketSummaryComponent } from './components/basket-summary/basket-summary.component';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';
import {CdkStepperModule} from '@angular/cdk/stepper';


@NgModule({
  declarations: [TextInputComponent, StepperComponent, BasketSummaryComponent, OrderTotalsComponent],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    CdkStepperModule,
    RouterModule,

  ],
  exports:[
    ReactiveFormsModule,
    FormsModule,
    BsDropdownModule,
    TextInputComponent,
    OrderTotalsComponent,
    CdkStepperModule,
    StepperComponent,
    BasketSummaryComponent
  ]
})
export class SharedModule { }
