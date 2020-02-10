# Choose Your Adventure

Simple web application which allows a player to choose their own path by picking  between two simple choices displayed on their screen in order to progress to the next set of  choices, until they get to one of the endings. and show the steps they took to get to the end of the game.

This project use .Net Core 3.1 and Angular CLI version 8.3.21

- ASP.Net Core 3.1
- Entity Framework Core
- SQL Server
- Xunit
- Angular 8
- Jest

## Project spec

- Clean Architecture
- DDD
- MediatR
- Seeding initial data by using Code First approach
- Logging and Exception Handling

## Development server

• Frontend 
webapp folder include client app 
Run `npm run start-frontend` for a frontend dev server. Navigate to `http://localhost:4200`. 

• Backend 
ChooseYourAdventure folder include bacnkend web API server
Build The Solution ChooseYourAdventure after that in Visual studio from Package manager console set default project to ChooseYourAdventure.Infrastructure and run `Update-Database` or you can run from cmd by `dotnet ef database update`
Build and run solution and navigate to `http://localhost:5000`

## Running unit tests

Run `npm run test` to execute the unit tests via [jest](https://jestjs.io).
