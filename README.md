KataFootballChampionship
========================

The purpose of this kata is to _develop software incrementally_, adding small features time by time.  
This is even a kata for teams: going forward, feature can be developed indipendently by more than one person, letting them make experiments with versioning pattern like branching, merges and so on.  

## Tips, hints, and recommendations
Be sure to take a look before starting.  

### Git and commit guidelines
A minor change to your commit message style can make you a better programmer.  
[Use conventional commits](https://www.conventionalcommits.org/).  

Format: `<type>(<scope>): <subject>`  

`<scope>` is optional.  

Example
~~~
feat: add hat wobble
^--^  ^------------^
|     |
|     +-> Summary in present tense.
|
+-------> Type: chore, docs, feat, fix, refactor, style, or test.
~~~

More examples:  

- `feat`: new feature for the user
- `fix`: bug fix for the user
- `docs`: changes to the documentation; no production code change
- `style`: formatting, missing semi colons, etc; no production code change
- `refactor`: refactoring production code, eg. renaming a variable
- `test`: adding missing tests, refactoring tests; no production code change
- `chore`: code cleanup, scripts, etc; no production code change

#### References:
- [Semantic commit messages](https://seesparkbox.com/foundry/semantic_commit_messages)
- [Karma guidelins for commit messages](http://karma-runner.github.io/1.0/dev/git-commit-msg.html)
- [Git aliases for conventional commits](https://github.com/fteem/git-semantic-commits)

## The kata
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
I want to generate a list of turns with relative dates  

### AT1: Having TeamA, TeamB, TeamC and TeamD teams, StartDate equal to 04/09/2016, DayOfWeek equal to Sunday, there will be 6 matches
* Load the list of team from a text file, one team per row.
* Ask user to input StartDate
* Ask user to input DayOfWeek
* generate the matches (only one match between each teams)
* print turns and matches to the video (console)

...

---  