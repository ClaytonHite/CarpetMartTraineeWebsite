# CarpetMartTraineeWebsite
##### This is my project for Software Development Course 2. The project originated by talking with a company I have worked for in the past. The goal is to make a website for the company that will let people register so they can sign up for trainings to become a flooring installer.

## Features

### Create 3 or more unit tests for your application
##### In the solution, under the project WebsiteProject.Tests, I have created 4 unit tests to verify the CRUD operation of making a profile works.

### Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
##### In the UserRepository class, the methods initalize dictionary parameters to be used in the DataAcess class when communicating with the database.

### Query your database using a raw SQL query, not EF
##### In the solution, under the project WebsiteDatabase, I have created stored procedures to be used for communicating with the database under the specific conditions.

### Have 2 or more tables (entities) in your application that are related and have a function return data from both entities.  In entity framework, this is equivalent to a join
##### When getting the classes a user has signed up for the user id is stored in the class table and is joined and returns the users that have signed up for the class.