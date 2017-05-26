export class User {
    userId: number;
    recordDT: Date;
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    emailConfirmed: number;
    tel1: string;
    tel2: string;
    address1: string;
    address2: string;
    city: string;
    province: string;
    country: string;
    postalCode: string;
    status: number;
    jwt: string;
    expires: Date;

    
}

export class UserMap{
    constructor() {
    }

    mapJSONtoUser(json:string): User{
        let user = new User();
        user.userId = 0;
        user.recordDT = new Date();
        user.firstName = '';
        user.lastName = '';
        user.email = '';
        user.emailConfirmed = 0;
        user.tel1 = '';
        user.tel2 = '';
        user.address1 = '';
        user.address2 = '';
        user.city = '';
        user.province = '';
        user.country = '';
        user.postalCode = '';
        user.jwt = '';
        user.expires = new Date();
        user.password = '';
        user.status = 0;
        if(json){
            let data = JSON.parse(json);
            user.userId = data.json() && data.json().userId;
            user.recordDT = data.json() && data.json().recordDT;
            user.firstName = data.json() && data.json().firstName;
            user.lastName = data.json() && data.json().lastName;
            user.email = data.json() && data.json().email;
            user.emailConfirmed = data.json() && data.json().emailConfirmed;
            user.tel1 = data.json() && data.json().tel1;
            user.tel2 = data.json() && data.json().tel2;
            user.address1 = data.json() && data.json().address1;
            user.address2 = data.json() && data.json().address2;
            user.city = data.json() && data.json().city;
            user.province = data.json() && data.json().province;
            user.country = data.json() && data.json().country;
            user.postalCode = data.json() && data.json().postalCode;
            user.jwt = data.json() && data.json().jwt;
            user.expires = data.json() && data.json().expires;
            user.password = data.json() && data.json().password;
            user.status = data.json() && data.json().status;
        }
        return user;
    }
}