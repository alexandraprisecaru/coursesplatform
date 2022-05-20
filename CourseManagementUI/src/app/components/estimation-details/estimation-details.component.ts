import { SelectionModel } from '@angular/cdk/collections';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Course } from 'src/app/models/course';
import { UserCourseAssignment } from 'src/app/models/userCourseAssigment';
import { DataAccessService } from 'src/app/services/dataaccess.service';

@Component({
  selector: 'app-estimation-details',
  templateUrl: './estimation-details.component.html',
  styleUrls: ['./estimation-details.component.scss']
})
export class EstimationDetailsComponent implements OnInit {

  userCourseAssignment: UserCourseAssignment;
  courses: Course[];

  constructor(private dataAccessService: DataAccessService,
    private dialogRef: MatDialogRef<EstimationDetailsComponent>,
    @Inject(MAT_DIALOG_DATA) data) {
      this.userCourseAssignment = data.userCourse;
  }

  async ngOnInit(): Promise<void> {
    this.courses = await this.dataAccessService.getCoursesByIds(this.userCourseAssignment.courseIds);
  }
}
