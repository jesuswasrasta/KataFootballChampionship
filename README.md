KataFootballChampionship
========================

The purpose of this kata is to _develop software incrementally_, adding small features step by step.  
This is a kata for groups: going forward, feature can be developed indipendently by more than one person or pair, letting them make experiments with versioning pattern like branching, merges and so on.  

## Tips, hints, and recommendations
Be sure to take a look at these before starting.  

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
The user of this software is the ChampionshipManager.  
He/she wants to generate championship's calendars, following some basic rules.  

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
I want to generate a calendar with the list of matches  

### AT1: 4 teams, one-way league
* Load the list of teams from a text file called `Teams.txt`; in this file, there is one team per row:
```
TeamA
TeamB
TeamC
TeamD
```
* Generate turns with matches (only one match between each teams)
* Print turns and matches to the video (console)
  
Having TeamA, TeamB, TeamC and TeamD teams, there will be 3 turns with 2 matches each.  
For example, this is a valid output:  
```
Turn 1
TeamA vs TeamB
TeamC vs TeamD

Turn 2
TeamA vs TeamC
TeamB vs TeamD

Turn 3
TeamA vs TeamD
TeamB vs TeamC
```
Note that at the moment there are no strict rules about matches sorting or away/home order.  
Following the previous rules, you can generate multiple valid calendars.  

### AT2: 2 teams, one-way league
Having only TeamA and TeamB, there will be only a turn with 1 match.  
This is a valid output:  
```
Turn 1
TeamA vs TeamB
```

### AT3: Having only TeamA, return an error
Print this message in console:
```
Provide at least 2 teams!
```

### AT4: Having no teams, return an error
Print this message in console:
```
Provide at least 2 teams!
```

### AT5: Having no input file, return an error
Print this message in console:
```
Provide a valid input file!
```
---

## Scenario 2: Calendar generation with dates
Given a list of teams,  
Given a start date,  
Given a day of the week,  
as a ChampionshipManager  
I want to generate a list of matches with relative dates  

### AT1: 

* Load the list of team from a text file, one team per row.
* Ask user to input `StartDate` in `dd/MM/yyyy` format
* Ask user to input `DayOfWeek` as a number, from `1=Monday`, to `7=Sunday`
* generate the matches (only one match between each teams)
* print turns and matches to the video (console)

For example, having TeamA, TeamB, TeamC and TeamD teams, `StartDate` equal to `01/01/2023`, `DayOfWeek` equal to `7` (Sunday), this is a valid calendar:  

```
Turn 1 - 01/01/2023
TeamA vs TeamB
TeamC vs TeamD

Turn 2 - 08/01/2023
TeamA vs TeamC
TeamB vs TeamD

Turn 3 - 15/01/2023
TeamA vs TeamD
TeamB vs TeamC
```
... to be continued ... 😁

---  
