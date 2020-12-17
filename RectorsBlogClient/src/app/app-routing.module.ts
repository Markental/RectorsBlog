import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreatepostComponent } from './createpost/createpost.component';
import { EditpostComponent } from './editpost/editpost.component';
import { ListPostsByCategoryComponent } from './list-posts-by-category/list-posts-by-category.component';
import { ListPostsComponent } from './list-posts/list-posts.component';
import { LoginComponent } from './login/login.component';
import { PostdetailsComponent } from './postdetails/postdetails.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';

const routes: Routes = [
  { path: '', redirectTo: 'posts', pathMatch: 'full' },
  { path: 'login', component: LoginComponent }, 
  { path: 'register', component: RegisterComponent },
  { path: 'create', component: CreatepostComponent, canActivate: [AuthGuardService] },
  { path: 'posts', component: ListPostsComponent },
  { path: 'posts/:id', component: PostdetailsComponent },
  { path: 'posts/:id/edit', component: EditpostComponent, canActivate: [AuthGuardService] },
  { path: 'posts/category/:name', component: ListPostsByCategoryComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuardService] },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
