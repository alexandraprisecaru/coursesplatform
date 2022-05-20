import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Course } from 'src/app/models/course';
import { DataAccessService } from 'src/app/services/dataaccess.service';
import { FormGroup, FormControl } from '@angular/forms';
import { UserCourseAssignment } from 'src/app/models/userCourseAssigment';
import { MatSort } from '@angular/material/sort';
import { EstimationCreatedComponent } from '../estimation-created/estimation-created.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {
  courses: MatTableDataSource<Course>;
  displayedColumns: string[] = ['select', 'name', 'duration'];
  selection = new SelectionModel<Course>(true, []);

  startDate: Date;
  endDate: Date;
  totalHours: number = 0;
  weeklyHours: number = 0;

  minDate: Date;

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl(),
  });

  @ViewChild(MatSort) sort: MatSort;

  constructor(private dataAccessService: DataAccessService, public dialog: MatDialog) {
  }

  async ngOnInit(): Promise<void> {
    const dbCourses = await this.dataAccessService.getCourses();
    this.courses = new MatTableDataSource<Course>(dbCourses);
    this.courses.sort = this.sort;

    this.minDate = new Date(Date.now());
  }

  openDialog(userCourseAssigment, courses) {
    this.dialog.open(EstimationCreatedComponent, {
      height: '600px',
      width: '800px',
      panelClass: 'custom-dialog-container',
      data: { userCourse: userCourseAssigment, courses: courses }
    });
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    this.totalHours = this.selection.selected
      .map(x => x.duration)
      .reduce((sum, current) => sum + current);

    const numSelected = this.selection.selected.length;
    const numRows = this.courses.data.length;

    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.courses.data.forEach(row => this.selection.select(row));
  }

  async calculate(event: Event) {
    const userId = "dummy";
    const coursesIds = this.selection.selected.map(x => x.id);
    const courseAssignment = new UserCourseAssignment(
      userId,
      coursesIds,
      this.startDate,
      this.endDate);

    const userCourses = await this.dataAccessService.assignCourses(courseAssignment);
    this.weeklyHours = userCourses.weeklyEstimate;

    this.openDialog(userCourses, this.selection.selected);
  }

  // moved logic to backend
  calculateWeeklyEstimate(startDate: Date, endDate: Date, totalHours: number): number {
    const difference = (endDate.getTime() - startDate.getTime());
    const days = Math.floor(difference / (60 * 60 * 24 * 1000));

    const weeks = days / 7;

    return totalHours / weeks;
  }
}
