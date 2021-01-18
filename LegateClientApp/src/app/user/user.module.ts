import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserListComponent } from './user-list/user-list.component';
import { RouterModule } from '@angular/router';
import { UserDetailsComponent } from './user-details/user-details.component';
import { UserCreateComponent } from './user-create/user-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserUpdateComponent } from './user-update/user-update.component';
import { UserDeleteComponent } from './user-delete/user-delete.component';



@NgModule({
  declarations: [UserListComponent, UserDetailsComponent, UserCreateComponent, UserUpdateComponent, UserDeleteComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {path:'list',component:UserListComponent},
      {path:'details/:id',component:UserDetailsComponent},
      {path:'update/:id',component:UserUpdateComponent},
      {path:'create', component: UserCreateComponent},
      {path:'delete/:id', component:UserDeleteComponent}
    ])
  ]
})
export class UserModule { }
