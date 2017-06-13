import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { JwtHelper } from 'angular2-jwt';
import { User } from '../_models/index';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService {
    public token: string;
    public refresh: string;
    private date;
    private expireDT: number;
    public user: User = new User();
    public jwtHelper: JwtHelper = new JwtHelper();
    public permissions: any[];

    constructor(private http: Http, private router: Router) {
        // set token if saved in local storage
        this.user = new User();
        if(JSON.parse(localStorage.getItem('profile'))){
            this.token = JSON.parse(localStorage.getItem('token'));
            this.user = JSON.parse(localStorage.getItem('profile'));
            this.refresh = JSON.parse(localStorage.getItem('refresh'));
            this.permissions = JSON.parse(localStorage.getItem('permissions'));
        }
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
                this.token = response.json() && response.json().access_token;
                this.refresh = response.json() && response.json().refreshToken;
                this.permissions = response.json() && response.json().permissions;
                if (this.token) {
                    this.getUserDetails(email, this.token).subscribe(me => { 
                        if(me.status == 'SUCCESS'){
                            this.user = me.data;
                        }

                        // store username and jwt token in local storage to keep user logged in between page refreshes
                        localStorage.setItem('profile', JSON.stringify(this.user ));
                        localStorage.setItem('token', JSON.stringify(this.token ));
                        localStorage.setItem('refresh', JSON.stringify(this.refresh ));
                        localStorage.setItem('permissions', JSON.stringify(this.permissions ));

                        console.log(
                            this.jwtHelper.decodeToken(this.token),
                            this.jwtHelper.getTokenExpirationDate(this.token),
                            this.jwtHelper.isTokenExpired(this.token)
                          );

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

    isTokenExpired(): boolean {
        return this.jwtHelper.isTokenExpired(this.token);
    }

    refreshToken(): Observable<boolean> {
        const headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        const options = new RequestOptions({ headers: headers });
        const body: URLSearchParams = new URLSearchParams();
        body.set('username', this.user.email);
        body.set('password', '');
        body.set('refreshToken', this.refresh);
        return this.http.post('http://localhost:59857/api/token', body.toString(), options)
            .map((response: Response) => {
                console.log("Response: ", response);
                // login successful if there's a jwt token in the response
                this.token = response.json() && response.json().access_token;
                this.refresh = response.json() && response.json().refreshToken;
                this.permissions = response.json() && response.json().permissions;

                if (this.token) {
                    localStorage.setItem('token', JSON.stringify(this.token ));
                    localStorage.setItem('refresh', JSON.stringify(this.refresh ));
                    localStorage.setItem('permissions', JSON.stringify(this.permissions ));

                    console.log('Token has been refreshed: ',
                        this.jwtHelper.decodeToken(this.token),
                        this.jwtHelper.getTokenExpirationDate(this.token),
                        this.jwtHelper.isTokenExpired(this.token)
                        );

                    // return true to indicate successful refresh
                    return true;
                } else {
                    // return false to indicate failed refresh
                    return false;
                }
            });
    }


    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('profile');
        localStorage.removeItem('token');
        localStorage.removeItem('refresh');
        localStorage.removeItem('permissions');
    }
}
