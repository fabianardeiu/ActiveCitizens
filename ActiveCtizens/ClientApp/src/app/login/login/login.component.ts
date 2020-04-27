import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  error: boolean;

  constructor(
    private router: Router,
    private fb: FormBuilder,

  ) {
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
    if (this.form.valid && this.form.controls['username'].value == 'fabi' && this.form.controls['password'].value == '1') {
      this.router.navigate(['map']);
    } else if (this.form.valid) {
      this.error = true;
    } else {
      this.form.markAllAsTouched;
    }
  }

}
