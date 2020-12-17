import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from '../models/Post';
import { Comment } from '../models/Comment';
import { AuthService } from '../services/auth.service';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-postdetails',
  templateUrl: './postdetails.component.html',
  styleUrls: ['./postdetails.component.css']
})
export class PostdetailsComponent implements OnInit {
  id!: number;
  post!: Post;
  commentForm!: FormGroup;
  comments: Array<Comment> =[];
  constructor(private postService: PostService, private activatedRoute: ActivatedRoute, private router: Router, private fb: FormBuilder, private authService: AuthService) {
    this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
      this.postService.getPostById(this.id).subscribe(p => {
        this.post = p;
        this.postService.getComments(this.post.postId).subscribe(c => {
          this.comments = c;
          this.commentForm = this.fb.group({
            'postId': [this.post.postId, Validators.required],
            'content': ['', Validators.required],
          });
        })
      });
    })
   }

  ngOnInit(): void {
  }

  delete(id: number) {
    this.postService.delete(id).subscribe(res => {
      this.router.navigate(["posts"]);
    });
  }
  
  edit(id: number) {
    this.router.navigate(['posts', id, 'edit']);
  }

  ///////

  fetchComments() {
    this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
      this.postService.getComments(this.id).subscribe(comments => {
        this.comments = comments;
      });
    })
    
  }

  createComment() {
    this.postService.createComment(this.commentForm.value).subscribe(res => {
      this.fetchComments();
    });
  }

  deleteComment(id: number) { 
    this.postService.deleteComment(id).subscribe(res => {
      this.fetchComments();
    })
  }

  get content() {
    return this.commentForm.get('content');
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
