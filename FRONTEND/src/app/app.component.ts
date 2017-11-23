import { UserFileDetails } from './UserFileDetails';
import { UserContentDetails } from './UserContentDetails';
import { UserDetails } from './UserDetails';
import { Component} from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { Router,ActivatedRoute, ParamMap} from '@angular/router';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/toPromise';

// import { Router,ActivatedRoute, ParamMap} from '@angular/router'


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  private userdetails : UserDetails[];
  Users_username: string;
  Users_userID : any;
  Users_fileID :any;
  trial_contentID: any;
  trial_User_userID: any;
  sharedwith_userID :any;
  contentID : any;
  headers: Headers;
  options: RequestOptions;
  gicha: any;
 searchletters: string;
 searchletter: string;
  FirstName : string;
  search: string = '';
  content: any;
  trial_fileID: any;
  yo: any;
  drops:any;
  constructor(public http: Http)
  {
    
    this.headers = new Headers({'Content-Type':'application/json'}); 
    this.headers.append('Accept', 'application/json');
    this.headers.append('Access-Control-Allow-Methods', 'POST, GET, OPTIONS, DELETE, PUT');
    this.headers.append('Access-Control-Allow-Origin', '*');
    this.headers.append('Access-Control-Allow-Headers', "X-Requested-With, Content-Type, Origin, Authorization, Accept, Client-Security-Token, Accept-Encoding");
    this.options = new RequestOptions({ headers: this.headers });
    this.Users_username = 'Baisakh'; //hardcoding users-name here

    this.http.get(('http://localhost:5000/api/UserDetails'),{headers:this.headers})
    .subscribe(result =>{this.drops= result.json() as UserDetails[],console.log(this.drops)});

    this.http.get(('http://localhost:5000/api/UserFileDetails'),{headers:this.headers})
    .subscribe(result =>{this.content= result.json().filter(obj => obj.userID == 1)as UserFileDetails[],console.log(this.content)});
  }

  fetchcontentID(con: any){
    
    console.log('contentID is'+con['contentID']);
    this.trial_contentID = con['contentID'];
    console.log('userID is'+ con['userID']);
    this.trial_User_userID = con['userID'];
    this.trial_fileID = con['fileID'];
  }
  
  autofill_dropdown(searchletters : string):Promise<any>{
    console.log(searchletters);
    // this.searchletters = searchletters['key'];

    // this.search = this.search + this.searchletters;
    // console.log(this.search);
    
    // console.log('hehe'+this.searchletter);
    // console.log(this.searchletters);
    return this.http.get(('http://localhost:5000/api/UserDetails/GetClientList/term?term='+/*this.search*/searchletters+''),{headers:this.headers})
    .toPromise()
    .then(result=> {
      this.gicha= result.json() as UserDetails[],console.log(this.gicha);
  }).catch(error => console.error(error));
  }
  
  extractUsers_userID(FirstName:string):Promise<any>{

    this.FirstName = FirstName;
    console.log(FirstName);
    //gets the user's ID here
    return this.http.get(('http://localhost:5000/api/UserDetails/'+this.Users_username+''),{headers:this.headers})
    .toPromise()
    .then(result => {
    this.Users_userID = result.json()['userID'] as UserDetails[],console.log(this.Users_userID);
    this.extract_contentID_of_to_be_shared_file();

    // window.location.reload();
  }).catch(error => console.error(error));

     
  
      //gets the email of the user with whom we are sharing our file
  //   this.http.get(('http://localhost:5000/api/UserDetails/'+FirstName+''),{headers:headers}).subscribe(result => {
  //     this.email = result.json()['email'] as UserDetails[],console.log(this.email);
  // }, error => console.error(error));

      

  
  

    // this.http.post('http://localhost:5000/api/mytable',JSON.stringify({id:3,fileID:35,sharewith:FirstName,userID:"sumanth"}),{headers:headers}).subscribe();
     
  }
  //gets the contentID of the content(file) we are sharing.
  private extract_contentID_of_to_be_shared_file (): Promise<any>{
    return this.http.get(('http://localhost:5000/api/UserContentDetails/'+this.Users_userID +''),{headers:this.headers})
   .toPromise()
   .then(result => {
     this.contentID = result.json()['contentID'] as UserContentDetails[],console.log(this.contentID);
    this.extract_details_of_the_reciever();
     })
    .catch(error => console.error(error));
  }

    private extract_details_of_the_reciever(): Promise<any> {
       //gets the full details of the user with whom we are sharing our file with
    return this.http.get(('http://localhost:5000/api/UserDetails/'+this.FirstName+''),{headers:this.headers})
  .toPromise()
  .then(result => {
    this.userdetails = result.json() as UserDetails[],console.log(this.userdetails);
    this.extract_userID_of_the_reciever();
})
  .catch(error => console.error(error))
    }

    private extract_userID_of_the_reciever():Promise<any>{
      //gets the userID of the user with whom we are sharing our file
  return this.http.get(('http://localhost:5000/api/UserDetails/'+this.FirstName+''),{headers:this.headers})
  
  .toPromise()
  .then(result => {
    this.sharedwith_userID = result.json()['userID'] as UserDetails[],console.log(this.sharedwith_userID);
    this.extract_FileID_of_the_file_share_by_user();
    })
    .catch( error => console.error(error));
  }

     private extract_FileID_of_the_file_share_by_user():Promise<any>{
       return this.http.get(('http://localhost:5000/api/UserFileDetails/'+this.Users_userID+''),{headers:this.headers})
       .toPromise()
       .then(result => {
        this.Users_fileID = result.json()['fileID'] as UserFileDetails[],console.log(this.Users_fileID);
        this.post_in_Content_Share_table()})
        .catch(error => console.error(error));
     }

     private post_in_Content_Share_table()
      {
      this.http.post('http://localhost:5000/api/ContentShare',JSON.stringify({contentID:this.trial_contentID,fileID:this.trial_fileID,sharedwith:this.sharedwith_userID,sharedby:this.trial_User_userID,createdby:this.Users_username}),{headers:this.headers}).subscribe();

      }  

    // private get_all_from_Content_Share_table():Promise<any>{
    //  return this.http.get(('http://localhost:5000/api/ContentShare'),({headers:this.headers}))
    //  .toPromise()
    //  .then();
    // }

    //not used as a function anywhere. have used window.location.reload() inside the 1st function's .then();
    reload()
{
  window.location.reload();
}
    
}

