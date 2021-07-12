import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiURL } from '../constants/ApiUrls';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  regForm: FormGroup;
  constructor(private fb: FormBuilder, private httpService: HttpService, private router: Router) { }

  ngOnInit() {
    this.init();
  }

  init() {
    this.regForm = this.fb.group({
      UserName: ['', Validators.required], EmailId: ['', Validators.required], Password: ['', Validators.required]
    })
  }

  onFormSubmit() {
    let param = {
      'UserName': this.regForm.controls['UserName'].value,
      'EmailId': this.regForm.controls['EmailId'].value,
      'Password': this.regForm.controls['Password'].value,
    }
    this.httpService.httpPost(ApiURL.Account.register, param).subscribe(res => {
      if (res['success']) {
        this.router.navigate(['']);
      }
    })
  }

}
