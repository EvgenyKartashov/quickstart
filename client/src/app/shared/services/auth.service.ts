import { Injectable } from '@angular/core';
import { User, UserManager } from 'oidc-client';
import { BehaviorSubject } from 'rxjs';
import { ConfigService } from './config.service';

@Injectable()
export class AuthService {
  // // Observable navItem source
  // private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // // Observable navItem stream
  // authNavStatus$ = this._authNavStatusSource.asObservable();

  private manager: UserManager;
  private user!: User | null;

  constructor(private configService: ConfigService) {
    let authConfig = configService.getAuthConfig();

    this.manager = new UserManager(authConfig);

    this.manager.getUser().then(user => {
      this.user = user;
      console.log(user);
      // this._authNavStatusSource.next(this.isAuthenticated());
    });
  }

  public login() {
    this.manager.signinRedirect();
  }

  public logout() {
    this.manager.signoutRedirect();
  }

  public isAuthenticated() {
    return this.user != null && !this.user.expired;
  }
}
