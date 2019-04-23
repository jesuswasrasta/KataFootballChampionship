KataFootballChampionship
========================

The purpose of this kata is to _develop software incrementally_, adding small features time by time.  
This is even a kata for teams: going forward, feature can be developed indipendently by more than one person, letting them make experiments with versioning pattern like branching, merges and so on.  

The goal of the software is to let the user generating football championship's calendar, following the rules the user can indicate.  
For example:

* Number of the teams
  * Can be an even number, so consider rest turns
* Championship start date
  * Day of the week when teams play, e.g. Sunday
* Stadium shared by more than one team (avoid conflicts)
* Championship kind
  * Home and away games
  * "Mirrored" championship turns
* Leader teams
  * User wants to setup "big matches" in a particular date
* ... other stories to come ...

Below some user-stories.

## Scenario 1: Basic calendar generation
Given a list of teams,  
as a ChampionshipManager  
I want to generate a list of matches  

### AT1: Having TeamA, TeamB, TeamC and TeamD teams, there will be 3 turns with 2 matches each
* Load the list of team from a text file, one team per row.
* generate turns with matches (only one match between each teams)
* print turns and matches to the video (console)

### AT2: Having only TeamA and TeamB, there will be only a turn with 1 match
* Load the list of team from a text file, one team per row.
* generate the matches (only one match between each teams)
* print the match to the video (console)

### AT3: Having only TeamA, return an error
* Load the list of team from a text file, one team per row.
* try to generate the matches (only one match between each teams)
* print error "Provide at least 2 teams!" to the video (console)

### AT4: Having no teams, return an error
* Load the list of team from a text file, one team per row.
* try to generate the matches (only one match between each teams)
* print error "Provide at least 2 teams!" to the video (console)

### AT5: Having no input file, return an error
* Try to load the list of team from a text file, one team per row.
* print error "Provide a valid input file!" to the video (console).

---

## Scenario 2: Calendar generation with dates
Given a list of teams,  
Given a start date,  
Given a day of the week,  
as a ChampionshipManager  
I want to generate a list of matches with relative dates  

### AT1: Having TeamA, TeamB, TeamC and TeamD teams, StartDate equal to 04/09/2016, DayOfWeek equal to Sunday, there will be 3 matches
* Load the list of team from a text file, one team per row.
* Ask user to input StartDate
* Ask user to input DayOfWeek
* generate the matches (only one match between each teams)
* print turns and matches to the video (console)

...

---  