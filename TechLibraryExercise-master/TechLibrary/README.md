# TechLibrary


### GitHub Repository 
[https://github.com/generic-widget-factory/TechLibraryExercise] 

### Prequisites
Visual Studio 2019 (.net core framework 3.x) - [Community Edition Download](https://visualstudio.microsoft.com/downloads/) 


### Solution Setup Instructions 
1. Clone the github repository locally 
2. Open **TechLibrary.sln**
3. Right Click the project “TechLibrary.Web”, select “Open Command Prompt Here” 
4. `$ npm install`   *(install the vue js client npm packages)* 
5. `$ npm run serve` *(run the client on localhost)*
6. **F5** in Visual Studio to launch the API project in Debug mode 
7. Select “Yes” to the dialog prompt to “trust the ASP.NET Core SSL certificate” 


### Coding Exercise Tasks 
Out of the box, the current solution uses a SQL Lite data source. The **BooksController** returns all books in the data store. Please complete the tasks below. 

#### Task: Pagination 
Return 10 results per page/request at the API and add pagination controls to the result set in the client UI 

#### Task: Search  
Create a search box control to filter/search the data store fields title and descr int the client UI, and the supporting functionality in the API 

#### Task: Edit Book 
On the book detail page, introduce a toggle into the client UI to toggle from read-only mode to edit mode.  Provide functionality in the API to support book detail edits/updates. 

#### Bonus Task: Add New Book 
Create functionality in the client UI to add a new book to the data store and update the API to save a new book detail item. 

### Considerations
This development exercise is intended to be a ~ 4-hour exercise (+/-).  Even though the current scope does not represent an enterprise application, please approach your application design with supporting such a production application in mind. 


Agile teams strive for maintainable, quality code that will be evaluated at build time in a Continuous Integration pipeline – please apply all applicable techniques and practices to this project towards these goals. 

If you find areas that you would choose to refactor, please do so and note your thought process behind the refactoring.

### Updated Feb 28 2020
### Completed above Tasks

#### Task: Pagination 
Client UI returns book records based on user input page size, default page size is 10. The paging is implemented server side using an extension method

#### Task: Search  
Books can be searched by title & description  

#### Task: Edit Book 
Books table title link opens a page to edit and save book details

#### Bonus Task: Add New Book 
Added a Add Book button  in the client UI to add a new book to the data store. 

### Test Project
Updated Test project to implement all Controller methods

### Exception Handling
Added some exception handling at Controller level. The inner exceptions bubble up to controller and get logged

### Swagger
Added Swashbuckle for API info & testing





