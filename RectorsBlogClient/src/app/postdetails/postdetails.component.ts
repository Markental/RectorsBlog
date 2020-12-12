import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from '../models/Post';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-postdetails',
  templateUrl: './postdetails.component.html',
  styleUrls: ['./postdetails.component.css']
})
export class PostdetailsComponent implements OnInit {
  id!: number;
  post!: Post;
  constructor(private postService: PostService, private activatedRoute: ActivatedRoute, private router: Router) {
    this.activatedRoute.params.subscribe(res => {
      this.id = res['id'];
      this.postService.getPostById(this.id).subscribe(res => {
        this.post = res;
      });
    })
   }

  ngOnInit(): void {

  }

  delete(id: number) {
    this.postService.deletePost(id).subscribe(res => {
      this.router.navigate(["posts"]);
    });
  }
  

}
