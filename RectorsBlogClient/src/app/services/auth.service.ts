import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loginPath = environment.apiUrl + "identity/login";
  private registerPath = environment.apiUrl + "identity/register";

  constructor(private http: HttpClient) { }

  login(data:any): Observable<any> {
    return this.http.post(this.loginPath, data);
  }

  register(data:any): Observable<any> {
    return this.http.post(this.registerPath, data);
  }

  saveUserId(id: string) {
    localStorage.setItem('userId', id);
  }
  getUserId() {
    return localStorage.getItem("userId");
  }

  saveUserName(name: string){
    localStorage.setItem('userName', name);
  }
  getUserName() {
    return localStorage.getItem("userName");
  }

  saveToken(token:any) {
    localStorage.setItem('token', token);
  }
  getToken() {
    return localStorage.getItem("token");
  }

  isAuthenticated(): boolean {
    if(this.getToken()) {
      return true;
    }
    else {
      return false;
    }
  }
}
