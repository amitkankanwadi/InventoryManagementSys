import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiURL } from '../constants/ApiUrls';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private httpService: HttpService, private router: Router) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.loginForm = this.fb.group({
      Email: ['', Validators.required], Password: ['', Validators.required]
    })
  }

  onFormSubmit() {
    if (this.loginForm.valid) {
      let param = {
        'EmailId': this.loginForm.controls['Email'].value,
        'Password': this.loginForm.controls['Password'].value,
      }
      this.httpService.httpPost(ApiURL.Account.login, param).subscribe(res => {
        if (res['success'] == true) {
          this.router.navigate(['/product']);
        }
      })
    }
  }
}
