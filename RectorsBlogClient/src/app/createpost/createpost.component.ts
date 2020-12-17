import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Category } from '../models/Category';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent implements OnInit {

  categories : Array<Category> = [];
  postForm! : FormGroup;
  constructor(private fb: FormBuilder, private postService: PostService, private router: Router) {
    this.postForm = fb.group({
      'title': ['', Validators.required],
      'posterURL': ['', Validators.required],
      'summary': ['', Validators.required],
      'body': ['', Validators.required],
      'categoryIds': ['']
    });
    this.postService.getCategories().subscribe(res => {
      this.categories = res;
    })
   }

  ngOnInit(): void {
  }

  create() {
    console.log(this.postForm.value)
    this.postService.create(this.postForm.value).subscribe(res => {
      this.router.navigate(['posts']);
    });
  }

  get title() {
    return this.postForm.get('title');
  }

  get posterURL() {
    return this.postForm.get('posterURL');
  }

  get summary() {
    return this.postForm.get('summary');
  }

  get body() {
    return this.postForm.get('body');
  }

}
