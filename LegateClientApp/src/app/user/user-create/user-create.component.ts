import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { UserForCreation } from '../../_interfaces/userForCreation.model'
@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent implements OnInit {
  public errorMessage: string = ""
  public userForm: FormGroup = new FormGroup({});
  constructor(private repo: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router) { }

  ngOnInit(): void {
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
public createUser =(userFormvalue :any) =>{
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
    let User: UserForCreation = {
      id: 0,
      name: userFormvalue.name,
      address: userFormvalue.address,
      postion: userFormvalue.postion,
      phone: +userFormvalue.phone,
      salary: +userFormvalue.salary,
      age: +userFormvalue.age,
      joiningDate: userFormvalue.joiningDate
    }
    console.log(User);
    const apiUrl = "api/User/AddUser"
    this.repo.create(apiUrl, User).subscribe((response) => {
      this.router.navigate(['/user/list'])

    }, (error) => {
      console.log(error);
      this.errorHandler.handleError(error);
      this.errorMessage= this.errorHandler.errorMessage;
    })
  }
  public redirectToUserList = () => {
    this.router.navigate(['/user/list']);
  }
 
}
