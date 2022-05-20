import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { GoogleLoginProvider, SocialAuthService } from "@abacritt/angularx-social-login";
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  user: any;
  loggedIn: boolean;
  constructor(
    private authService: SocialAuthService,
    private cookieService: CookieService,
    private router: Router) {

    this.authService.authState.subscribe(user => {
      this.user = user;
      console.log(user);
    });

    // this.authService.authState.subscribe((user) => {
    //   this.user = user;
    //   this.loggedIn = (user != null);

    //   if (this.loggedIn) {
    //     console.log(this.user);

    //     this.saveToCookie("authToken", this.user.authToken);
    //     this.saveToCookie("idToken", this.user.idToken);
    //   }
    // });
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot)
    : Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let existentCookie = this.cookieService.get("authToken");
    if (!existentCookie) {
      this.signInWithGoogle();
    } else {
      return true;
    }
  }

  /**
   * Checks if the given value is valid, in which case it saves it to cookies under the given name.
   * @param name name of the cookie
   * @param value
   */
  private saveToCookie(name: string, value: string) {
    if (!value || value === "invalid") {
      return;
    }

    let existentCookie = this.cookieService.get(name);
    if (existentCookie === value) {
      return;
    }

    this.cookieService.set(name, value, 1, "/");
  }

  // signInWithGoogle(): Promise<void> {
  //   return this.authService.signIn(GoogleLoginProvider.PROVIDER_ID, { ux_mode: "redirect" }).then((user) => {
  //     if (user !== null && user.authToken) {
  //       this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
  //         this.router.navigate([""]));
  //     }
  //   });
  // }

  // googleLoginOptions = {
  //   scope: 'profile email'
  // }; // https://developers.google.com/api-client-library/javascript/reference/referencedocs#gapiauth2clientconfig

  public signInWithGoogle(): void {
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  // signInWithGoogle(): void {
  //   this.authService.signIn(GoogleLoginProvider.PROVIDER_ID).then((user) => {
  //     if (user !== null && user.authToken) {
  //       this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
  //         this.router.navigate([""]));
  //     }
  //   }).catch(data => {
  //     this.authService.signOut();
  //     this.router.navigate(['login']);
  //   });
  // }

  googleLoginOptions = {
    scope: 'profile email',
    ux_mode: "redirect"
  };

}
function delay(arg0: number) {
  throw new Error('Function not implemented.');
}

