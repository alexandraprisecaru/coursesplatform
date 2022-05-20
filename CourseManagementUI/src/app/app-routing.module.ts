import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CoursesComponent } from './components/courses/courses.component';
import { EmptyComponent } from './components/empty/empty.component';
import { EstimationsComponent } from './components/estimations/estimations.component';
import { AuthGuard } from './guards/auth.guard';

// const routes: Routes = [
//   { path: "courses", component: CoursesComponent, canActivate: [AuthGuard] },
//   { path: "estimations", component: EstimationsComponent, canActivate: [AuthGuard] },
//   { path: "", component: CoursesComponent, canActivate: [AuthGuard] },
//   { path: "**", component: CoursesComponent, canActivate: [AuthGuard] },
// ];

const routes: Routes = [
  { path: "courses", component: CoursesComponent },
  { path: "estimations", component: EstimationsComponent },
  { path: "", component: CoursesComponent },
  { path: "**", component: CoursesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
