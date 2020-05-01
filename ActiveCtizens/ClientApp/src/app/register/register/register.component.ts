import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthentificationService } from '../../services/authentification.service';
import { RegisterUser } from '../../models/RegisterUser';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private authService: AuthentificationService
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  register() {
    if (this.form.valid) {
      let registerUser = new RegisterUser();
      registerUser.name = this.form.controls['name'].value;
      registerUser.username = this.form.controls['username'].value;
      registerUser.password = this.form.controls['password'].value;

      this.authService.register(registerUser).subscribe(() => this.router.navigate(['']));
    }
  }

}
