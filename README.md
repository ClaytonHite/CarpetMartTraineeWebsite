# CarpetMartTraineeWebsite
##### This is my project for Software Development Course 2. The project originated by talking with a company I have worked for in the past. The goal is to make a website for the company that will let people register so they can sign up for trainings to become a flooring installer.

## Features

### Create 3 or more unit tests for your application
##### In the solution, under the project WebsiteProject.Tests, I have created 4 unit tests to verify the CRUD operation of making a profile works.

### Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
##### In the UserRepository class, the methods initalize dictionary parameters to be used in the DataAccess class when communicating with the database.

### Query your database using a raw SQL query, not EF
##### In the solution, under the project WebsiteDatabase, I have created stored procedures to be used for communicating with the database under the specific conditions.

### Have 2 or more tables (entities) in your application that are related and have a function return data from both entities.  In entity framework, this is equivalent to a join
##### When getting the class a user has signed up for the user id and class id is stored in a seperate table and all 3 are joined and returns the users that have signed up for the class.

## Extras

### Weather API call
##### You can check the weather in a city by name in the US under the nav bar link Weather, it updates every 10 minutes from each query. Stores it in a list and checks wether to update when called.

### Added MS user login with encrpted sql database
##### You have to register first and then currently you can click the verify link since I did not set up an email sender. You then login into the account you made. When logged in you can CRUD a profile that gets stored in the DB and Check the weather.

## Instructions for running
### Update-Database
##### Open the package manager console and run the command Update-Database

### Publish the WebsiteDatabase Project
##### Right click the WebsiteDatabase Project
##### Click Publish...
##### In Target database connection field, find your connection created when you did update-database
##### Then in the Database name field put WebsiteDatabase

### Change connection string
##### For the CarpetMartTraineeWebsite project and also the CarpetMartTraineeWebsite.Tests.
##### Go into the appsettings.json and change the Server= on both to the one set up when you did update-database.
##### Change the DefaultConnection Database= to the generated database from update-database (if its not already in there) AND Change the WebsiteDatabase Database= to WebsiteDatabase

### Register an account
##### Now that the DB is setup you can run the project and click register in the top right.
##### Verify your account by clicking the link on the next page
##### Goto the profile navigation item in the top right and add a test profile. Everything but Address Line 2 is needed
##### Then you can goto classes and Add a new class.
##### Go back to classes and you can see it added in and you can register to it.
##### Then if you go back to classes you can view the users signed up for it.
##### If you make another account, then add profile, and then sign up for the same class you can check the list and watch the different test accounts register.
##### You can also make another class and repeat the process

### Weather tab
##### When logged in you can search the weather by city name in the US. It'll update every 10 minutes.
# Thank You!
##### Thanks for taking the time to look at my project if you have any questions feel free to message me on slack!
