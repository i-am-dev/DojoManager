import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { User, UserMap } from '../_models/index';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService {
    public token: string;
    private date;
    private expireDT: number;
    public user: User = new User();

    constructor(private http: Http, private userMap: UserMap, private router: Router) {
        // set token if saved in local storage

        console.log('Current User: ');
        this.user = new User();
        if(JSON.parse(localStorage.getItem('currentDojoUser'))){
            this.user = JSON.parse(localStorage.getItem('currentDojoUser'));
            //this.user = this.userMap.mapJSONtoUser(JSON.parse(localStorage.getItem('currentDojoUser')));
        }

        console.log(this.user);
    }

    login(email: string, password: string): Observable<boolean> {
        const headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        const options = new RequestOptions({ headers: headers });
        const body: URLSearchParams = new URLSearchParams();
        body.set('username', email);
        body.set('password', password);
        return this.http.post('http://localhost:59857/api/token', body.toString(), options)
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                const token = response.json() && response.json().access_token;
                const expireDT = response.json() && response.json().expires_in;
                if (token) {
                    let data;
                    this.getUserDetails(email, token).subscribe(me => { 
                        if(me.status == 'SUCCESS'){
                            //data = me.data;
                            this.user = me.data;
                        }
                        // set token property
                        this.user.jwt = token;
                        this.user.expires = new Date((new Date()).getTime() + ((expireDT - 30) * 1000));
                        this.user.email = email;
                        this.user.password = password;
    
                        //console.log(this.user);
                        // store username and jwt token in local storage to keep user logged in between page refreshes
                        localStorage.setItem('currentDojoUser', JSON.stringify(this.user ));
    
                        // return true to indicate successful login
                        this.router.navigate(['/']);
                        return true;
                    });
                } else {
                    // return false to indicate failed login
                    return false;
                }
            });
    }

    private getUserDetails(email:string, token:string){
        // add authorization header with jwt token
        const headers = new Headers({ 'Authorization': 'Bearer ' + token,
                                    'Content-Type': 'application/x-www-form-urlencoded' });
        const options = new RequestOptions({ headers: headers });
        const body: URLSearchParams = new URLSearchParams();
        body.set('email', email);
        return this.http.post('http://localhost:59857/api/user/whoami', body.toString(), options)
            .map((response: Response) => response.json());
    }

    refreshJWT(): Observable<boolean>{
        const headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        const options = new RequestOptions({ headers: headers });
        const body: URLSearchParams = new URLSearchParams();
        body.set('username', this.user.email);
        body.set('password', this.user.password);
        return this.http.post('http://localhost:59857/api/token', body.toString(), options)
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                const token = response.json() && response.json().access_token;
                const expireDT = response.json() && response.json().expires_in;
                if (token) {
                    // set token property
                    this.user.jwt = token;
                    this.user.expires = new Date((new Date()).getTime() + ((expireDT - 30) * 1000));
                    //console.log(this.user);
                    // store username and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentDojoUser', JSON.stringify(this.user ));

                    // return true to indicate successful login
                    return true;
                } else {
                    // return false to indicate failed login
                    return false;
                }
            });
    }

    checkIfJWTExpired(model: User): boolean{
        if(model.jwt != null && model.jwt != ''){
            if((new Date(model.expires)) > (new Date())){
                return true;
            }
        }
        return false;
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('currentDojoUser');
    }
}
