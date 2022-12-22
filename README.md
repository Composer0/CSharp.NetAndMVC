# C#, ASP.NET, PostgreSQL, and more.

## Week 3 : Six Degrees (Contact and Categories Applicaiton for Use Amongst Multiple Users)
### Project Name: Six Degrees

Learning how to use .Net 6 and PostgreSQL while building a Contact Manager Applicaiton.


Day 8
- create interface for AddressBookService and service file for AddressBookService
- register the interface and inject it into the controller
- write the code for getting user categories
- write code for saving categories to a contact
- write code for checking if the contact already exists in the category

Day 5
- create Interface for ImageService as well as Service file for ImageService
- add suffixes for image sizes
- show default image if none is uploaded
- convert file data
- save the image to the database
- change the image in the view using JavaScript
- register IImageService in Program.cs


Day 4
Main steps that occurred include:
- add States Enum to the view
- remove AppUserId from the ModelState
- inject the UserManager
- set AppUserID and Created fields
- convert the birthdate
- change what happens after save is clicked.

Day 3
Main steps that occurred include:
- add Identity and inject the SignInManager
- force links not to render if the user is not signed in
- secure controllers using Authorize attribute
- secure Categories controller using Authorize attribute
- apply template styling to code and make updates.

Day 1 & 2
The main steps that have occurred over the past two days have included: 
- create a new AppUser model using inheritance
- add FirstName & LastName properties
- enforce a maximum and minimum lengths
- add a NotMapped property
- add a new migration and update the database
- add new scaffolded items
- update the registration view to include first and last names
- handle a connection string error
- handle a layout page error
- register a new user and login
- add models for categories, contacts, and created a migration to combine categories and contacts.
- stylized application using a bootstrap template.
- created personal branding for the webpage using canva.




## Week 1-2 : C# Coding Challenges
Palindrome Checker Folder and More

Learned how to use the MVC design model and apply it to my writing in C#. My first project in C# was to create a Palindrome Applicaiton. This was followed by FizzBuzz and then my loan calculator. As an added challenge to myself I learned how to route these applcaitons to each other through different view folders that were initially created to help me organize the created apps. At this time all three apps are visible on the same web app which was deployed on the Azure hosting service. 

https://orionpalmer-csharp-dsa.azurewebsites.net/

This application uses the MVC design model and applied it to my writing in C#. These projects primarily operate using 'For' loops to filter through the data to check and modify the values. Within this applciation is Palindrome Checker, FizzBuzz Finder, and my Loan Calculator. Web app was published on the Microsoft Azure hosting service.
