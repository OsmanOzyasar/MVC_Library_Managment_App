# Library Management System

## Project Description
Library Management System is a simple web application where you can add and list books and authors. It is developed using ASP.NET Core MVC and does not use any database. All data is stored in memory while the application is running.

## Technologies Used
- .NET 8
- ASP.NET Core MVC
- Visual Studio
- BootStrap

## Installation and Running
To run this project, follow these steps:

1. **Open Visual Studio** and load the project.
2. **Press F5** to run the project.
3. Alternatively, you can navigate to the project directory in the terminal and run:
   ```sh
   dotnet run
   ```
   However, running it through Visual Studio is the simplest method.

## Project Structure (MVC)
The project contains **three controllers**:

### 1. **AuthorController** (Author Operations)
This controller manages operations related to authors.
- `List` - Lists all authors.
- `Create` - Displays the form to add a new author and saves it.
- `Edit` - Edits an existing author.
- `Delete` - Deletes an author.
- `Details` - Shows the selected author’s details and their books.

### 2. **BookController** (Book Operations)
This controller manages operations related to books.
- `List` - Lists all books.
- `Create` - Displays the form to add a new book and saves it.
- `Edit` - Edits an existing book.
- `Delete` - Deletes a book.
- `Details` - Shows the selected book’s details and its author.

### 3. **HomeController** (Home Page)
This controller manages general pages.
- `Index` - Displays the home page.
- `IsEmpty` - If the book and author lists are empty, redirects to a "No items to display" page.
- `About` - Displays the about page.

## Database Structure
This project does not use a database, but the logical structure follows:
- **An author can have multiple books.**
- **Each book can have only one author.**
- The author's detail page lists their books.
- The book's detail page shows its author.

## Sample Routes
Here are some key routes used in the project:

- **List books:** `/Book/List`
- **Add a new book:** `/Book/Create`
- **List authors:** `/Author/List`
- **Add a new author:** `/Author/Create`
- **Home page:** `/Home/Index`
- **Redirect page if lists are empty:** `/Home/IsEmpty`

## Screenshots
![Örnek Resim](https://github.com/OsmanOzyasar/MVC_Library_Managment_App/blob/master/images/Main_Menu.png)
![Örnek Resim](https://github.com/OsmanOzyasar/MVC_Library_Managment_App/blob/master/images/Add_Author.png)
![Örnek Resim](https://github.com/OsmanOzyasar/MVC_Library_Managment_App/blob/master/images/Add_Book.png)
![Örnek Resim](https://github.com/OsmanOzyasar/MVC_Library_Managment_App/blob/master/images/Author_List.png)
![Örnek Resim](https://github.com/OsmanOzyasar/MVC_Library_Managment_App/blob/master/images/Book_List.png)
![Örnek Resim](https://github.com/OsmanOzyasar/MVC_Library_Managment_App/blob/master/images/Author_Detail.png)
![Örnek Resim](https://github.com/OsmanOzyasar/MVC_Library_Managment_App/blob/master/images/Book_Detail.png)
![Örnek Resim](https://github.com/OsmanOzyasar/MVC_Library_Managment_App/blob/master/images/About.png)
## Contribution
This project is created as an assignment. Those who want to improve or add new features can modify the code according to their needs.

