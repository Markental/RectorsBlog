import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../models/Category';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-editpost',
  templateUrl: './editpost.component.html',
  styleUrls: ['./editpost.component.css']
})
export class EditpostComponent implements OnInit {
  postForm!: FormGroup;
  postId!: number;
  categories: Array<Category> = [];
  postCategories: Array<Category> = [];
  constructor(private fb: FormBuilder, private postService: PostService, private route: ActivatedRoute, private router: Router) {
    this.route.params.subscribe(params => {
      this.postId = params["id"];
      this.postService.getPostById(this.postId).subscribe(res => {
        this.postService.getCategories().subscribe(c => {
          this.categories = c;
        })
        this.postService.getCategoriesByPostId(res.postId).subscribe(pc => {
          this.postCategories = pc;
        })
        this.postForm = this.fb.group({
          'postId': [res.postId, Validators.required],
          'title': [res.title, Validators.required],
          'posterURL': [res.posterURL, Validators.required],
          'summary': [res.summary, Validators.required],
          'body': [res.body, Validators.required],
          'categoryIds': []
        });
        
      });
      
    });
   }

  ngOnInit(): void {
  }

  edit() {
    // console.log(this.postForm.value)
    this.postService.edit(this.postForm.value).subscribe(res => {
      this.router.navigate(['posts', this.postId]);
    });
  }
  checkCategory(id: number) {
    let bool = false;
    if (this.postCategories.map(e=>e.categoryId).indexOf(id) != -1) {
      bool= true;
    }
    return bool;
  }

}
