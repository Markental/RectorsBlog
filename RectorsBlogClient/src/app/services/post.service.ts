import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Post } from '../models/Post';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private postPath = environment.apiUrl + "posts/"
  constructor(private http: HttpClient, private authService: AuthService) { }

  create(data: any): Observable<Post> {
    return this.http.post<Post>(this.postPath + "create", data, {headers: {"Authorization": `Bearer ${this.authService.getToken()}`}});
  }
}
