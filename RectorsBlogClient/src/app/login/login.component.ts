import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.loginForm = this.fb.group({
      'username': ['', [Validators.required]],
      'password': ['', [Validators.required]]
    })
    console.log(this.loginForm);
   }

  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.loginForm.value).subscribe(data => {
      this.authService.saveToken(data.token);
      this.authService.saveUserId(data.id);
      this.authService.saveUserName(data.userName);
      this.router.navigate(['posts'])
    });
    
  }

  get username() {
    return this.loginForm.get('username');
  }
  get password() {
    return this.loginForm.get('password');
  }
}
