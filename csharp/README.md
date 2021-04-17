# KataFootballChampionship, C# edition
Notes about the kata execution.  

## Paths
Below you find some example commands for the Linux shell.  
Beware the paths if you work on Windows 🙂  

## Create the solution
Go to your source base folder.  
Create the solution file:
~~~ sh
# sln: sln command for solutions
# -o: output dir: Creates the soluton file KataFootballChampionship.sln in KataFootballChampionship folder
dotnet new sln -o KataFootballChampionship
~~~

Create a class library project for tests in NUnit; use `test` for MStest or other for your framework of choice
~~~ sh
dotnet new nunit -o KataFootballChampionship.Test
~~~

Create a class library project for source code
~~~ sh
dotnet new classlib -o KataFootballChampionship.Core
~~~

Add the projects to the solution
~~~ sh
dotnet sln KataFootballChampionship.sln add \
    "./KataFootballChampionship.Test/KataFootballChampionship.Test.csproj" \
    "./KataFootballChampionship.Core/KataFootballChampionship.Core.csproj"
~~~

Reference to Core project in Test one 
~~~ sh
dotnet add \
    "./KataFootballChampionship.Test/KataFootballChampionship.Test.csproj" \
    reference \
    "./KataFootballChampionship.Core/KataFootballChampionship.Core.csproj"
~~~

Run the test
~~~ sh
dotnet test \
    "./KataFootballChampionship.Test/KataFootballChampionship.Test.csproj"
~~~

If test passes, you have a working (empty) solution :)

