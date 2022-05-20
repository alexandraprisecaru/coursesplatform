import { Course } from "./course";

export class UserCourseAssignment {

  id: string;
  idUser: string;
  courseIds: string[];
  startDate: Date;
  endDate: Date;
  weeklyEstimate: number;
  totalHours: number;

  constructor(idUser: string, courses: string[], startDate: Date, endDate: Date) {
    this.idUser = idUser;
    this.courseIds = courses;
    this.startDate = startDate;
    this.endDate = endDate;
  }
}
