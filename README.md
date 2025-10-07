# Task 2: Singleton Implementation

## Student Info
- Name: Brady DeVost
- ID: 01198776

## Pattern: Singleton
### Implementation
The first thing I did was create the script for the game manager and an associated empty object to put the script on. I then added every variable and function that
my game would need (score, upgrades, the ability to increased and decreases score). Then, I created a second script (called Button) that could call the GameManager instance
to actiave the neccesary function. Lastly, I added the final script for the Audio Manager which let me add sound effects for whenever the player interacts with the game.

### Game Integration
With as little as 3 scripts I have a fully functional clicker idle game. The Game Manager takes care of every single variable and function that the game needs to keep track of,
while the button script lets me call them with any interactable UI object. While it doesn't seem that impressive the Singleton method allows me to continue to expand upon my game
in novel ways because all of the data is handled by my Game Manager Object.

## Game Description
- Title: Clicker Game
- Controls: Click the button to increase your score. Use your score to buy upgrades to make your clicks better or to make your auto clicks faster.
Prestiege to make your clicks permanently better.
- Objective: Prestiege with a requirement of 15 upgrades to win.

## Repository Stats
- Total Commits: 7
- Development Time: 10 hours
