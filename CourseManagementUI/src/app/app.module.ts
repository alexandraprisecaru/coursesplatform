import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app.component';
import { CoursesComponent } from './components/courses/courses.component';
import { HeadComponent } from './components/head/head.component';
import { EmptyComponent } from './components/empty/empty.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material.module';
import { MatNativeDateModule } from '@angular/material/core';
import { EstimationsComponent } from './components/estimations/estimations.component';
import { EstimationDetailsComponent } from './components/estimation-details/estimation-details.component';
import { CookieService } from 'ngx-cookie-service';

import { SocialLoginModule, SocialAuthServiceConfig, GoogleLoginProvider} from "@abacritt/angularx-social-login";
import { EstimationCreatedComponent } from './components/estimation-created/estimation-created.component';

// let authService = new SocialAuthService(
//   {
//     autoLogin: true,
//     providers: [{
//       id: GoogleLoginProvider.PROVIDER_ID,
//       provider: new GoogleLoginProvider("989131655048-uoc4tm3atkhq158oa49ncsb4r5fsquig.apps.googleusercontent.com", {
//         scope: 'profile email'
//       })
//     }],
//     onError: (error: any) => console.log("An error occurred while attempting to authenticate with Google")
//   }
// );

// export function provideAuthService() { return authService; }

@NgModule({
  declarations: [
    AppComponent,
    CoursesComponent,
    EstimationsComponent,
    EstimationDetailsComponent,
    EstimationCreatedComponent,
    HeadComponent,
    EmptyComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MaterialModule,
    HttpClientModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    SocialLoginModule
  ],
  providers: [
    CookieService,
    // {
    //   provide: SocialAuthService, useFactory: provideAuthService
    // },
    {
      provide: "SocialAuthServiceConfig",
      useValue: {
        autoLogin: true,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              "773990800060-jv8irjvn40sca31vnq789gkhemokiflr.apps.googleusercontent.com"
            )
          }
        ]
      } as SocialAuthServiceConfig
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
