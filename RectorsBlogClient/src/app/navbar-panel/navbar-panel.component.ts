import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from '../models/Category';
import { AuthService } from '../services/auth.service';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-navbar-panel',
  templateUrl: './navbar-panel.component.html',
  styleUrls: ['./navbar-panel.component.css']
})
export class NavbarPanelComponent implements OnInit {
  categories: Array<Category> =[];
  constructor(private authService: AuthService, private router: Router, private postService: PostService) {
    this.postService.getCategories().subscribe(res => {
      this.categories = res;
    })
   }

  ngOnInit(): void {
  }

  getUserName() {
    return this.authService.getUserName();
  }

  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  logout(){
    document.cookie = 'token=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
    localStorage.removeItem('token');
    sessionStorage.removeItem('token');
    localStorage.removeItem('userId');
    sessionStorage.removeItem('userId');
    localStorage.removeItem('userName');
    sessionStorage.removeItem('userName');
    this.router.navigate(['/']);
  }



}
