# StudentskaSluzba-10-console-app
C# console app that simulates interaction between student and student service registry, for faculty enrolment, chosing and taking exams

Main meny and language used throughout project is Serbian

Since I expressed interest in learning to code, my professor gave me a task and time to complete it.
My task was to create a console application to simulate interaction between a student and faculty during the enrollment phase. I created a menu from where the user could control the process. The next step was creating a method for enrolling a new student. If all data was filled correctly and verified, a new Student object was placed in a LinkedList. From the main menu, you could search through the list using StudentIndexNumber and view the enrolled student's data and/or edit it. The primary difference between objects is the index number, which is unique for each object. I used it as a makeshift primary key since I did’nt use real database, using XML document for data storage instead. After that, I created a list of courses a student could enroll in and added functionality for choosing them. Next was the functionality to take a previously selected exam and receive a grade for it. Finally, you could choose to view all student data from the menu including average score.

Maintainability Index: 67 Cyclomatic Complexity: 272 Depth of Inheritance: 1 Class Coupling: 23 Lines of Source code: 1.814 Lines of Executable code: 600


There are many other uncovered logical verifications in this project
