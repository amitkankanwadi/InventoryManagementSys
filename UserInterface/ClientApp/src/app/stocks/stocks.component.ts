import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiURL } from '../constants/ApiUrls';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-stocks',
  templateUrl: './stocks.component.html',
  styleUrls: ['./stocks.component.css']
})
export class StocksComponent implements OnInit {
  stockForm: FormGroup;

  constructor(private fb: FormBuilder, private httpService: HttpService, private router: Router) { }

  ngOnInit() {
    this.init();
  }

  init() {
    this.stockForm = this.fb.group({
      productName: ['', Validators.required], units: ['', Validators.required], unitsSold: ['', Validators.required]
    })
  }

  addStock() {
    var param = {
      'ProductName': this.stockForm.controls['productName'].value,
      'Units': this.stockForm.controls['units'].value,
      'UnitsSold': this.stockForm.controls['unitsSold'].value,
    }
    this.httpService.httpPost(ApiURL.Product.addStock, param).subscribe(res => {});
  }

  updateStock() {
    var param = {
      'ProductName': this.stockForm.controls['productName'].value,
      'Units': this.stockForm.controls['units'].value,
      'UnitsSold': this.stockForm.controls['unitsSold'].value,
    }
    this.httpService.httpPost(ApiURL.Product.updateStock, param).subscribe(res => {});
  }

  deleteStock() {
    var param = {
      'ProductName': this.stockForm.controls['productName'].value,
      'Units': this.stockForm.controls['units'].value,
      'UnitsSold': this.stockForm.controls['unitsSold'].value,
    }
    this.httpService.httpPost(ApiURL.Product.deleteStock, param).subscribe(res => {});
  }
}
