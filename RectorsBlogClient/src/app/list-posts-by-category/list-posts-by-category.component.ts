import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from '../models/Post';
import { AuthService } from '../services/auth.service';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-list-posts-by-category',
  templateUrl: './list-posts-by-category.component.html',
  styleUrls: ['./list-posts-by-category.component.css']
})
export class ListPostsByCategoryComponent implements OnInit {
  name!: string;
  posts: Array<Post> = [];
  constructor(private postService : PostService, private router: Router, private authService: AuthService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.fetchPosts();
  }

  fetchPosts() {
    this.route.params.subscribe(params => {
      this.name = params['name'];
      this.postService.getPostsByCategoryName(this.name).subscribe(posts => {
        this.posts = posts;
        console.log(this.posts);
      });
    })
    
  }

  getDateTime(date: string) {
    var convertedDate = new Date(date);
    return convertedDate;
  }

  delete(id: number) {
    this.postService.delete(id).subscribe(res => {
      this.fetchPosts();
    });
  }

  edit(id: number) {
    this.router.navigate(['posts', id, 'edit']);
  }

  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  isMine(authorId: number): boolean {
    if(authorId.toString() == this.authService.getUserId()) {
      return true;
    }
    else {
      return false;
    }
  }

}
