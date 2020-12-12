import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from '../models/Post';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-list-posts',
  templateUrl: './list-posts.component.html',
  styleUrls: ['./list-posts.component.css']
})
export class ListPostsComponent implements OnInit {
  posts: Array<Post> = [];
  constructor(private postService : PostService) { }

  ngOnInit(): void {
    this.fetchPosts();
  }

  fetchPosts() {
    this.postService.getPosts().subscribe(posts => {
      this.posts = posts;
      console.log(this.posts);
    })
  }

  getDateTime(date: string) {
    var convertedDate = new Date(date);
    return convertedDate;
  }

  delete(id: number) {
    this.postService.deletePost(id).subscribe(res => {
      this.fetchPosts();
    });
  }

}
