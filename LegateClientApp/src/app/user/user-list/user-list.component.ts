import { Component, OnInit } from '@angular/core';
import {User,Users} from '../../_interfaces/user.model';
import {RepositoryService} from '../../shared/services/repository.service';
import {ErrorHandlerService} from '../../shared/services/error-handler.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  constructor(private repo : RepositoryService, private router: Router,private ErrorServ: ErrorHandlerService) { }
  public userList:Users | undefined;
  public users: User[]=[];
  public errorMessage: string="";
  ngOnInit(): void {
    this.getAllUsers();
  }
  public getAllUsers =() =>{
    let apiAddress: string = "api/User/GetAll";
    this.repo.getData(apiAddress).subscribe(response =>{
      this.userList = response as Users
      this.users= this.userList.users
    },(error) =>{
      this.ErrorServ.handleError(error);
      this.errorMessage= this.ErrorServ.errorMessage;
    })
  }
  public getUserDetails = (id :any)=>{
    let detailsUrl=`/user/details/${id}`
    this.router.navigate([detailsUrl]);
  }
  public redirectToUpdatePage =(id :any) =>{
    const url:string =`/user/update/${id}`
    this.router.navigate([url]);
  }
  public redirectToDeletePage =(id :any) =>{
    const url:string =`/user/delete/${id}`
    this.router.navigate([url]);
  }
}
