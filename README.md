# span-challenge
### To run the app
- Verify that you have installed .NET Core Runtime with version '8.0.x'
- Clone the repo 
- go to the solution folder
- run - dotnet restore
- run - dotnet build --no-restore
- go to the GameScores folder 
- run - dotnet run
- have fun

###Sample input:
Lions 3, Snakes 3
Tarantulas 1, FC Awesome 0
Lions 1, FC Awesome 1
Tarantulas 3, Snakes 1
Lions 4, Grouches 0

###Expected output:
Tarantulas, 6 pts
Lions, 5 pts
FC Awesome, 1 pt
Snakes, 1 pt
Grouches, 0 pts