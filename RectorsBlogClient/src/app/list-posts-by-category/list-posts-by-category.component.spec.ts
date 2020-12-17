import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPostsByCategoryComponent } from './list-posts-by-category.component';

describe('ListPostsByCategoryComponent', () => {
  let component: ListPostsByCategoryComponent;
  let fixture: ComponentFixture<ListPostsByCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListPostsByCategoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPostsByCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
