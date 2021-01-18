import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {EnvironmentUrlService} from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private httpClient:HttpClient, private envUrl: EnvironmentUrlService) { }
  public getData(route:string){
    return this.httpClient.get(this.createRoute(route,this.envUrl.urlAddres) )
  }
  public getDataById(route:string){
    return this.httpClient.get(this.createRoute(route,this.envUrl.urlAddres) )
  }
  public create(route :string , body:any){
    return this.httpClient.post(this.createRoute(route,this.envUrl.urlAddres),body,this.generateHeaders());
  }
  public update(route :string , body:any){
    return this.httpClient.put(this.createRoute(route,this.envUrl.urlAddres),body,this.generateHeaders());
  }
  public Delete(route :string){
return this.httpClient.delete(this.createRoute(route,this.envUrl.urlAddres) );
  }
  private createRoute =(route:string, envUrl:string) => {
    return `${envUrl}/${route}`
  }
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
  }
}
