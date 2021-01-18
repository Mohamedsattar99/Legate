import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import {userDetails} from '../../_interfaces/userDetails.model';
@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
 public errorMessage:string="";
 public userDetails: userDetails | undefined 
  constructor(private router : Router,private activeroute: ActivatedRoute, private errorHanlder: ErrorHandlerService, private repo : RepositoryService) { }

  ngOnInit(): void {
    this.getUserDetails();
  }
  public  getUserDetails =() =>{
     let id= this.activeroute.snapshot.params["id"];
     let apiUrl=`api/User/Get/id?id=${id}`
     this.repo.getData(apiUrl).subscribe((response)=>{
       this.userDetails= response as userDetails;
       console.log(this.userDetails);
     },(error)=>{
       this.errorHanlder.handleError(error);
       this.errorMessage= this.errorHanlder.errorMessage;
      console.log(error);
     })
  } 
}
