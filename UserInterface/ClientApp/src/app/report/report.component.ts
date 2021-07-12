import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiURL } from '../constants/ApiUrls';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  reportForm: FormGroup;
  data: any;
  constructor(private fb: FormBuilder, private httpService: HttpService, private router: Router) { }

  ngOnInit() {
    this.init();
  }

  init() {
    this.reportForm = this.fb.group({
      productName: ['', Validators.required], fromDate: ['', Validators.required], toDate: ['', Validators.required]
    })
  }

  getReport() {
    var param = {
      'FromDate': this.reportForm.controls['fromDate'].value,
      'ToDate': this.reportForm.controls['toDate'].value,
      'ProductName': this.reportForm.controls['productName'].value
    }

    this.httpService.httpPost(ApiURL.Product.getReport, param).subscribe(res => {
      if (res['success'] == true) {
        this.data = res['data'];
      }
    })
  }

}
