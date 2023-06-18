import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { user } from './user';
import { subservice } from './subservice';
import { subscriptionplan } from './subscriptionplan';
import { user1 } from './user1';
import { payment } from './payment';

@Injectable({
  providedIn: 'root'
})
export class MainService {
  userData:any;

  subServices:any[]=[];

  subTier:any[]=[];

  tierDet:any;

  pay:payment=new payment();

  updateTier:subscriptionplan=new subscriptionplan();

  userPath="https://localhost:7164/api/Users";
  servicePath="https://localhost:7164/api/ProductServices";
  subServicePath="https://localhost:7164/api/SubProductServices";
  userSubscriptionPath="https://localhost:7164/api/UserSubscriptions"
  subscriptionPath="https://localhost:7164/api/SubscriptionTiers";
  constructor(private http:HttpClient) { }

  //users

  getAllUsers(){
    return this.http.get(this.userPath);
  }

  addUser(user:user1){
    return this.http.post(this.userPath,user);
  }


  deleteUser(id:number){
    return this.http.delete(this.userPath+'?id='+id);
  }

  //service
  addService(formData:any){
    return this.http.post(this.servicePath,formData);
  }

  getService(){
    return this.http.get(this.servicePath);
  }


  deleteService(id:number){
    return this.http.delete(this.servicePath+'?id='+id);
  }
  //subservice
  getSubSeviceRemaining(){
    return this.http.get(this.subscriptionPath+'/Subscription');
  }
  addSubService(formData:subservice){
    return this.http.post(this.subServicePath,formData);
  }
  addImage(formData:FormData){
    return this.http.post(this.subServicePath+'/AddImg',formData)
  }
  getSubSerDet(){
    return this.http.get(this.subServicePath+'/SubServDet');
  }
  deleteSubService(id:number){
    return this.http.delete(this.subServicePath+'?id='+id);
  }
  getServiceById(id:number){
    return this.http.get(this.subServicePath+'/ById?id='+id);
  }
  //subscription
  addSubscription(data:subscriptionplan){
    return this.http.post(this.subscriptionPath,data);
  }

  getSubscriptionTier(){
    return this.http.get(this.subscriptionPath+'/SubDetails');
  }
  getSubscriptionTierbyId(id:number){
    return this.http.get(this.subscriptionPath+'/'+id);
  }
  updateSubscriptionTier(){
    return this.http.put(this.subscriptionPath,this.updateTier);
  }

  getPlanById(id:number){
    return this.http.get(this.subscriptionPath+'/ById?id='+id);
  }

  getTierById(id:number){
    return this.http.get(this.subscriptionPath+'/'+id);
  }

  //UserSubscription
  getReport(){
    return this.http.get(this.userSubscriptionPath+'/Report');
  }

  payment(){
    this.pay.userId=this.userData.userId;
    this.pay.subscriptionTierId=this.tierDet.subscriptionTierId;
    this.pay.duration=this.tierDet.duration;
    return this.http.post(this.userSubscriptionPath,this.pay);

  }

  //userauth
  authenticate(data:user){
    return this.http.post(this.userPath+'/authenticate',data);
  }

  //Tokens
  storeToken(tokenValue:string){
    localStorage.setItem('token',tokenValue);
  }

  getToken(){
    return localStorage.getItem('token');
  }

  isLoggedIn():boolean{
    return !!localStorage.getItem('token');
  }
  signout(){
    localStorage.clear();
  }

  //Total
  getTotalUsers(){
    return this.http.get(this.userPath+'/Count');
  }
  getTotalServices(){
    return this.http.get(this.servicePath+'/Count');
  }
  getTotalSubServices(){
    return this.http.get(this.subServicePath+'/Count');
  }
  getTotalUserSubscriptions(){
    return this.http.get(this.userSubscriptionPath+'/Count');
  }
  getTotalUserNotSubscribed(){
    return this.http.get(this.userSubscriptionPath+'/Notsub');
  }
}
