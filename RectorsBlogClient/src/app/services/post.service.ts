import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Post } from '../models/Post';
import { Comment } from '../models/Comment';
import { AuthService } from './auth.service';
import { Category } from '../models/Category';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private postPath = environment.apiUrl + "posts/";
  private commentPath = environment.apiUrl + "comments/";
  private categoryPath = environment.apiUrl + "categories/";
  constructor(private http: HttpClient, private authService: AuthService) { }

  create(data: any): Observable<Post> {
    return this.http.post<Post>(this.postPath + "create", data);
  }

  getPosts() : Observable<Array<Post>> {
    return this.http.get<Array<Post>>(this.postPath);
  }

  getPostById(id: number) :Observable<Post> {
    return this.http.get<Post>(this.postPath + id);
  }

  delete(id: number) {
    return this.http.delete(this.postPath + id);
  }

  edit(data: Post) {
    return this.http.put<Post>(this.postPath+data.postId, data);
  }

  getPostsByCategoryName(name: string) {
    return this.http.get<Array<Post>>(this.postPath + "category/" + name);
  }

  /////////////
  getComments(postId: number): Observable<Array<Comment>> {
    return this.http.get<Array<Comment>>(this.commentPath + postId);
  }

  createComment(data: any): Observable<any> {
    return this.http.post<Post>(this.commentPath, data);
  }

  deleteComment(id: number) {
    return this.http.delete(this.commentPath + id);
  }

  /////////////
  getCategories(): Observable<Array<Category>> {
    return this.http.get<Array<Category>>(this.categoryPath);
  }

  getCategoriesByPostId(postId: number): Observable<Array<Category>> {
    return this.http.get<Array<Category>>(this.categoryPath+"GetCategoriesByPostId/"+postId)
  }

}
