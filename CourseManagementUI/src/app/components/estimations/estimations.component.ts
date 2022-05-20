import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { UserCourseAssignment } from 'src/app/models/userCourseAssigment';
import { DataAccessService } from 'src/app/services/dataaccess.service';
import { SelectionModel } from '@angular/cdk/collections';
import { MatDialog } from '@angular/material/dialog';
import { EstimationDetailsComponent } from '../estimation-details/estimation-details.component';

@Component({
  selector: 'app-estimations',
  templateUrl: './estimations.component.html',
  styleUrls: ['./estimations.component.scss']
})
export class EstimationsComponent implements OnInit {

  userCourses: MatTableDataSource<UserCourseAssignment>;
  displayedColumns: string[] = ['courses', 'startDate', 'endDate', 'totalHours', 'weeklyEstimate'];
  selection = new SelectionModel<UserCourseAssignment>(true, []);

  @ViewChild(MatSort) sort: MatSort;

  constructor(private dataAccessService: DataAccessService, public dialog: MatDialog) {
  }

  async ngOnInit(): Promise<void> {
    const userId = "dummy";
    const usercourses = await this.dataAccessService.getAssignedCourses(userId);
    this.userCourses = new MatTableDataSource<UserCourseAssignment>(usercourses);
    this.userCourses.sort = this.sort;
  }

  openDialog(row) {
    this.dialog.open(EstimationDetailsComponent, { 
      height: '600px',
      width: '800px', 
      panelClass: 'custom-dialog-container',
      data: { userCourse: row } });
  }
}
