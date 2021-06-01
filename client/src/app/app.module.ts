import { HttpClientModule } from '@angular/common/http';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { SecureComponentComponent } from './components/secure-component/secure-component.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { AuthService } from './shared/services/auth.service';
import { ConfigService } from './shared/services/config.service';

function loadAppConfig(config: ConfigService) {
  return () => config.loadAppConfig();
}

function loadAuthConfig(config: ConfigService) {
  return () => config.loadAuthConfig();
}

@NgModule({
  declarations: [AppComponent, HomeComponent, SecureComponentComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [
    ConfigService,
    AuthService,
    AuthGuard,
    {
      provide: APP_INITIALIZER,
      useFactory: loadAuthConfig,
      deps: [ConfigService],
      multi: true,
    },
    {
      provide: APP_INITIALIZER,
      useFactory: loadAppConfig,
      deps: [ConfigService],
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
