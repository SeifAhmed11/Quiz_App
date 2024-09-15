# Quiz App

This is a full-stack quiz application developed using **ASP.NET** for the backend API and **React** for the frontend. The app allows users to log in with their email and name, and their scores are saved. If the user achieves a higher score, it automatically updates. Each time, the user is presented with 5 random questions, and at the end, they can see the correct answers.

## Features
- User login with email and name
- User scores are saved and updated if a higher score is achieved
- Each quiz session presents 5 different random questions
- At the end of the quiz, the user can view the correct answers

## Technologies Used
- **ASP.NET Core** for the backend API
- **SQL Server** for database management
- **React** for the frontend
- **Material UI** for styling and components
- **JavaScript** for logic and dynamic functionality
- **C#** for backend logic
- **HTML** and **CSS** for structure and styling

## Backend Setup (ASP.NET API):

- Open the solution in Visual Studio.
- Restore NuGet packages.
- Update your connection string for SQL Server in `appsettings.json`.
- Run migrations to create the necessary database tables.

## Frontend Setup (React):

1. Navigate to the `client` directory.
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the development server:
   ```bash
   npm start
   ```

## Usage:

1. Register or login with your email and name.
2. Answer the 5 random questions.
3. Review your score and see the correct answers.
4. Your score is saved and updated if it's higher than previous scores.

## Contribution:

Feel free to contribute to the project by opening a pull request or submitting issues for bugs and feature requests.

