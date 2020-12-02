import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent implements OnInit {

  postForm : FormGroup;
  constructor(private fb: FormBuilder, private postService: PostService) {
    this.postForm = fb.group({
      'title': ['', Validators.required],
      'posterURL': ['', Validators.required],
      'summary': ['', Validators.required],
      'body': ['', Validators.required],
    });
   }

  ngOnInit(): void {
  }

  create() {
    this.postService.create(this.postForm.value).subscribe(res => {
      console.log(res);
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
