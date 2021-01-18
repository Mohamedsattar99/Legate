import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { userDetails } from 'src/app/_interfaces/userDetails.model';
import { UserForUpdate } from 'src/app/_interfaces/userForUpdate.model';

@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrls: ['./user-update.component.css']
})
export class UserUpdateComponent implements OnInit {

 public errorMessage:string="";
 public userDetails!: userDetails;
 public userForm: FormGroup = new FormGroup({});
 constructor(private router : Router,private activeroute: ActivatedRoute, private errorHanlder: ErrorHandlerService, private repo : RepositoryService) { }

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
  ngOnInit(): void {
    this.getUserDetails();
    this.userForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(15)]),
      address: new FormControl('', [Validators.required, Validators.maxLength(25)]),
      postion: new FormControl('', [Validators.required, Validators.maxLength(20)]),
      joiningDate: new FormControl('', [Validators.required]),
      age: new FormControl('', [Validators.required, Validators.pattern('^\\d{2}$')]),
      salary: new FormControl('', [Validators.required,Validators.pattern("^[0-9]*$")]),
      phone: new FormControl('', [Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")])
    })
  }
public updateUser =(userFormvalue :any) =>{
  if(this.userForm?.valid){
    this.excuteCreationOfUser(userFormvalue);
  }

}

public validateControl = (controlName:string) =>{
 if(this.userForm?.controls[controlName].invalid && this.userForm.controls[controlName].touched) 
 return true;

 return false;
}
public hasError = (controlName :string , errorName: string) =>{
    if(this.userForm?.controls[controlName].hasError(errorName))
    return true;
     
    return false;
}
  public excuteCreationOfUser = (userFormvalue :any) => {
    let User: UserForUpdate = {
      id: this.userDetails.userId,
      name: userFormvalue.name,
      address: userFormvalue.address,
      postion: userFormvalue.postion,
      phone: +userFormvalue.phone,
      salary: +userFormvalue.salary,
      age: +userFormvalue.age,
      joiningDate: userFormvalue.joiningDate
    }
    console.log(User);
    const apiUrl = "api/User/Update"
    this.repo.update(apiUrl, User).subscribe((response) => {
      this.router.navigate(['/user/list'])

    }, (error) => {
      console.log(error);
      this.errorHanlder.handleError(error);
      this.errorMessage= this.errorHanlder.errorMessage;
    })
  }
  public redirectToUserList = () => {
    this.router.navigate(['/user/list']);
  }
 
}
