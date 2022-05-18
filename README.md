![Alt Text](https://github.com/alexandraprisecaru/coursesplatform/blob/master/current_status2.gif)

Current functionality:
* User can see a list of courses (name + duration in hours) 
* User can select one or more courses, the total number of hours is displayed on the page
* User can select a date range in wish he wants to take the courses, specifying the start and end date
* When at least one course is selected and a date range is specified, user can calculate the estimated hours/per week he should dedicate to studying by clicking the calculate button
* The service is called which adds the data to db, checks the courses ids are correct and generates the weekly estimate
* A dialog is displayed in which all information about the current selection is displayed, including total hours and estimated hours per week
* User can see all calculation usage from the past by going to the /estimations route. Action can be done via UI buttons as well


* The service communicates with a local mongoDB database in which it stores all courses and all user course activity
* If there are no courses in the db, for ease of testing, the service will populate the database

Future implementation:
* Enable google authentication in order to interact with real users
 	- attempted to do this, but currently it fails, google authentication behavior changed lately. UI is ready to incorporate authentication, having guards setup to prevent unauthenticated users
* Add unit tests & integration tests
* Style UI better, currently it's very simple
* Dockerize backend
* Improve error handling


Assumptions made:
* Thought it'd be nice to have a starting & ending date for each course, but from my understanding it's not in the scope of the excercise
* Calculating an estimate for a few courses doesn't necessarily mean a user can't perform the same calculation again
	- thought it'd be nice to "enroll" to courses (have the ability to drop out if needed) and by doing this, the courses selected won't be available for calculation anymore, will be grayed out
