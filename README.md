# cs302final
A simple tower defense game in Unity for CS302's final project at UTK.

# Resources
Tilemaps: https://www.youtube.com/watch?v=ryISV_nH8qw


CS 302 Final Project Report
Git Repository: https://github.com/trevormangrum/cs302final
Timelogs
Nolan Askew
10/18/21: 2 hours -- worked in lab to create milestones and a sample object
2 hours -- created a sample project and followed a tutorial on how to use scripting in
Unity
10/19/21:
2 hours -- created the UI for the main menu and had it connect to a level scene that has a
sphere that moves when spacebar is pressed
10/26/21: 1.5 hours -- created a pause menu and linked level select buttons
10/31/21: .5 hours -- scaled everything to fit the size of the screen
11/11/21: 1 hour -- watched a tutorial for a 2D tower defense game in Unity
11/19/21: .5 hours -- learned and messed around with tower scripts
11/20/21: .5 hours -- created basic level UI
11/22/21: 2 hours -- gave towers a graphic and bullets and have them shoot at the enemies
11/22/21: 1 hour -- made towers placable
11/24/21: .5 hours -- added shop manager and made UI work
11/24/21: 1 hour -- fixed towers placed by UI and attempted to add money when enemy is killed
11/26/21: 1 hour -- made algorithm for tower to target enemy with the highest speed
11/28/21: 1.5 hours -- made towers not placeable on path, displayed player money, made new
tasks
11/28/21: 1.5 hours -- created topbar, indicators, and info panel
11/29/21: 2 hours -- fixed tower placements and finished sidebar UI
11/29/21: 4 hours -- debugged issues with git and project and added UI to all levels
Total: 23.5 hours
Andrew Hines
10/15/2021 Unity Essentials tutorial
3:20-4:20 1 1
10/18/2021 Practice Template
3:30-5:00 1.5 2.5
10/21/2021 Lego Template
4-4:30 .5 3
10/22/2021 Advanced 2DTemplate
3:15-5:00 1.75 4.75
10/26/2021 Found Youtube playlist detailing Tower defense games in Unity. Watched and
followed along with the first episodes 6:00-7:30 1.5 6.25
10/28/2021 Followed alone with episode 3
2:00-3:15 1.25 7.5
11/2/2021 Tried to convert map from 3d tutorial to 2d
11:30-12:30 1 8.5
11/5/2021 Scratched the 3d tutorial, watched a 2d tutorial and followed along
3:15-4:15 1 9.5
11/14/2021 Began work on 2d basic Towers
5:00-7:00 2
11/26/2021 Continued work on multiple tower targeting types,
12:00-2:00 2 11.5
11/28/2021 Continued work on multiple tower targeting types, found and fixed push issue in
my repo that has been around since the beginning 4:00-6:00 2 13.5
11/28/2021 Art Work to make towers looks better/add faces
6:00-8:00 2 15.5
11/29/2021 Finished work on photoshopping sprites and adding lasers
11:30-1:30 2 17.5
11/29/2021 Recorded Soundtrack, imported Tower Noises
5:00-8:00 3 20.5
Total: 20.5 hours
Trevor Mangrum
10/18/2021 -- 2 hrs -- Worked on milestones and setting up repo
10/21/2021 -- 2 hrs -- Worked on learning the basics of the Unity Editor and created a basic
Level Select UI.
10/21/2021 -- 2 hrs -- Worked on learning about sprite creation and tilesets/tilemaps to create the
first towers/levels.
10/29/2021 -- 4 hrs -- Started learning about how tilesets/tilemaps are made in Unity.
10/30/2021 -- 2 hrs -- Made first set of sprites for tileset.
11/10/21 -- 2 hrs -- Watched tutorials on tilemaps and adding tile data in Unity
11/10/21 -- 1 hr -- Worked on a new tile palette for ground tiles
11/11/21 -- 0.5hrs -- Worked on test enemy spritesheet
11/24/2021 -- 2 hrs -- Worked on adding multiple enemies and updating their sprites based on
which direction they're facing.
11/25/2021 -- 2 hrs -- Started work on the wave system, ran into a lot of trouble with it
11/26/2021 -- 2 hrs -- Finished wave system
11/29/2021 -- 2 hrs -- Reworked components of wave system, added more rounds
Total: 23.5 hours
TOTAL GROUP HOURS: 67.5
Meetings
We did most of our communications through a group chat throughout the entirety of the project
in which we discussed directions we wanted the project to go, issues with the project, and also
updated each other on what we were working on.
10/26/21 -- Met after class for 20 minutes to discuss which data structure we wanted to use for
our project. We decided we didn’t want to use Dijkstra’s anymore and instead just use waypoints
for pathfinding for the enemies
11/11/21 -- Further discussed which data structure/algorithm we wanted to use for our BYOS
presentation. We decided we wanted to use and present quicksort.
11/18/21 -- After our presentation and working on the project more, we decided to just use
lists/queues as our data structures for the projects. The waypoints were used in a way similar to
queues and all of the enemies were kept in a list for the towers to target specific enemies based
on their attributes.
11/28/21 -- Met on discord for 30 minutes to discuss and assign final tasks for us to work on to
complete our project.
11/29/21 -- Met in the afternoon for about an hour to resolve a conflict with git
11/29/21 -- Met at night for an hour to discuss final additions to the project and also debug issue
with tower placements
Manual
CHARLES VS CARLS TOWER DEFENSE
Nolan Askew, Andrew Hines, Trevor Mangrum
Build Instructions
You may download the .exe file from Github to run the game. To access the game in Unity,
the project may be cloned from GitHub using "git clone
https://github.com/trevormangrum/cs302final.git", and then opened using Unity Hub
Game Instructions
● Once the game loads, you may press the “Play” button, and then select a level to play the
game
● Once the level loads, you may place towers down by clicking a build button on the side
panel and then dragging the tower to the desired build space and clicking again to place
the tower
● To begin a wave of enemies, press the spacebar
● Once all the enemies have been destroyed or reached the end of the map, you may begin
the next wave
● At any time, you may press the escape key to pause the game and either resume, return to
the title screen, or quit the game
● Enemies drop money on death, and this may be used to purchase more towers
● Once you have passed all rounds, you win! Try another level
Known Bugs
● For the best experience, run the game within Unity, but for convenience, you may use the
.exe file. The UI was designed in Unity, so if the project is opened with the .exe file, the
UI will likely be off depending on the screen resolution being used, but the game should
still be playable. If the tower build buttons aren’t visible, then the project may need to be
opened in Unity or another screen may need to be used
● Once all the rounds have been beaten, the rounds display at the top messes up, and there
is no Game Won screen, as it had issues in development, and wasn’t able to be fixed in
time
● Sometimes there is a rare bug in which rounds are not able to be spawned, which happens
randomly, and we believe it is an issue with a variable going out of range or something of
the like. If this happens, the game needs to be restarted
● The player is able to place towers on the paths in the levels, since we weren’t able to
figure out a way to prevent this in time for the project to be due
● The first bullet from the towers each round doesn’t go towards any enemies, but the shot
is still registered, so this is just a visual bug