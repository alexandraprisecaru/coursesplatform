import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Course } from '../models/course';
import { UserCourseAssignment } from '../models/userCourseAssigment';

import { environment } from './../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DataAccessService {

  constructor(private httpClient: HttpClient) { }

  async getCourses(): Promise<Course[]> {
    const url = `${environment.coursesApiUrl}/course/all`;
    return await this.httpClient.get<Course[]>(url).toPromise<Course[]>();
  }
  
  async getCoursesByIds(ids:string[]): Promise<Course[]> {
    const url = `${environment.coursesApiUrl}/course/byIds`;
    return await this.httpClient.post<Course[]>(url, ids).toPromise<Course[]>();
  }
  
  async addCourse(course: Course): Promise<Course> {
    const url = `${environment.coursesApiUrl}/course/add`;
    return await this.httpClient.post<Course>(url, course).toPromise<Course>();
  }

  async addCourses(courses: Course[]): Promise<Course[]> {
    const url = `${environment.coursesApiUrl}/course/add-mulitple`;
    return await this.httpClient.post<Course[]>(url, courses).toPromise<Course[]>();
  }

  async assignCourses(userCourseAssignment: UserCourseAssignment): Promise<UserCourseAssignment> {
    const url = `${environment.coursesApiUrl}/courseassignment`;
    return await this.httpClient.post<UserCourseAssignment>(url, userCourseAssignment).toPromise<UserCourseAssignment>();
  }

  async getAssignedCourses(userId: string): Promise<UserCourseAssignment[]> {
    const url = `${environment.coursesApiUrl}/CourseAssignment/${userId}`;
    return await this.httpClient.get<UserCourseAssignment[]>(url).toPromise<UserCourseAssignment[]>();
  }
}
