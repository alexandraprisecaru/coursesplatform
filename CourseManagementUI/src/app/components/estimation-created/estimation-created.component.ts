import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { UserCourseAssignment } from 'src/app/models/userCourseAssigment';
import { DataAccessService } from 'src/app/services/dataaccess.service';
import { EstimationDetailsComponent } from '../estimation-details/estimation-details.component';

@Component({
  selector: 'app-estimation-created',
  templateUrl: './estimation-created.component.html',
  styleUrls: ['./estimation-created.component.scss']
})
export class EstimationCreatedComponent implements OnInit {

  userCourseAssignment: UserCourseAssignment;
  courses: Course[];

  constructor(private dataAccessService: DataAccessService,
    private router: Router,
    private dialogRef: MatDialogRef<EstimationDetailsComponent>,
    @Inject(MAT_DIALOG_DATA) data) {
    this.userCourseAssignment = data.userCourse;
    this.courses = data.courses
  }

  async ngOnInit(): Promise<void> {
    this.courses = await this.dataAccessService.getCoursesByIds(this.userCourseAssignment.courseIds);
  }

  onButtonClick(event: Event): void {
    this.dialogRef.close();
    this.router.navigate(["estimations"]);
  }
}
