import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiURL } from '../constants/ApiUrls';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  productForm: FormGroup;
  products = [];
  data: any;

  constructor(private fb: FormBuilder, private httpService: HttpService, private router: Router) { }

  ngOnInit() {
    this.init();
    this.getProductList();
  }

  init() {
    this.productForm = this.fb.group({
      productName: ['', Validators.required], description: ['', Validators.required], rate: [0, Validators.required]
    })
  }

  getProductList() {
    this.httpService.httpPost(ApiURL.Product.getAll, null).subscribe(res => {
      this.data = res['data'];
      this.productForm.patchValue({
        productName: this.data.productName,
        description: this.data.description,
        rate: this.data.productRate
      });
     });
  }

  addProduct() {

    let param = {
      'ProductName': this.productForm.controls['productName'].value,
      'Description': this.productForm.controls['description'].value,
      'ProductRate': this.productForm.controls['rate'].value,
    }
    console.log(param)
    this.httpService.httpPost(ApiURL.Product.add, param).subscribe(res => { });
  }

  updateProduct() {
    let param = {
      'ProductName': this.productForm.controls['productName'].value,
      'Description': this.productForm.controls['description'].value,
      'ProductRate': this.productForm.controls['rate'].value,
    }
    this.httpService.httpPost(ApiURL.Product.update, param).subscribe(res => { });
  }

  deleteProduct() {
    let param = {
      'ProductName': this.productForm.controls['productName'].value,
      'Description': this.productForm.controls['description'].value,
      'ProductRate': this.productForm.controls['rate'].value,
    }
    this.httpService.httpPost(ApiURL.Product.delete, param).subscribe(res => { });
  }
}
