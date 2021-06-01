import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserManagerSettings } from 'oidc-client';

@Injectable()
export class ConfigService {
  private appConfigUri = 'assets/auth-config.json';
  private authConfigUri = 'assets/auth-config.json';

  private appConfig: any;
  private authConfig!: UserManagerSettings;

  constructor(private http: HttpClient) {}

  public loadAppConfig() {
    return this.http.get<any>(this.appConfigUri)
      .toPromise()
      .then(data => this.appConfig = data);
  }

  public loadAuthConfig() {
    return this.http.get<any>(this.authConfigUri)
      .toPromise()
      .then(data => this.authConfig = data);
  }

  public getAppConfigByKey(key: string) {
    return this.appConfig[key];
  }

  public getAppConfig() {
    return this.appConfig;
  }

  public getAuthConfig() {
    return this.authConfig;
  }
}
