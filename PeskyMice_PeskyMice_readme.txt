Names: Nandini Ramakrishnan, Sean Schoettler, Owen Huggins, Tanner Iley, Amber Ephraim

Emails: nramakri6@gatech.edu,aephraim6@gatech.edu, ohuggins3@gatech.edu, sschoettler3@gatech.edu, tanner.iley@gatech.edu
Canvas usernames: nramakri6, aephraim6, ohuggins3, sschoettler3, tiley3

Start Scene file: We have a main menu, which is the MainMenu scene file.

Main Scene(s) of the Project: We have 2 main scenes, Stage 1 and the Boss Stage.

How to play and what parts of the level to observe technology requirements: The main objective is to get the cheese. That's how the player wins and passes each stage. For Stage 1, the mouse appears. An intro with the camera plays and shows the entire room (it can be skipped by pressing any key). Then, it has to avoid the mousetrap and cockroach (or shoot at them), and then get to the power handle. The fastest way to get to the power handle is to go backwards, go to the mousehole on the left, and that will transport the mouse to the sink. From there, it has to jump up, and then get to the power handle like that. Once it's there, it has to go near the handle and press the 'Enter' button. That jumps the player up to the top. Once it gets to the top of the cabinets, it can navigate to another mousehole and avoid some obstacles. That mousehole will transport it to the table in the middle of the room. On that table rests the cheese. When the mouse collects the cheese, it will get transported to the next stage (the Boss Stage).
To play the Boss Stage, the player has to kill all of the spiders.
Project Game Requirements:
1. Our game is implemented in Unity.
2. It has a 3D world.
3. Our main character is an animated Mouse. It has animations to make it move right, left, forward, backward (using the arrow keys) and pressing the space bar make it jump up. 'Q' and 'E' makes it rotate. On its own, the mouse has special animations that make it slowly sway back and forth on its own. It also has different animations for moving and jumping. The mouse also has the ability to shoot blue "bullets" at anything in front of it.
4. We have AI implemented in the cockroaches (in Stage 1) and spiders in the boss stage.
5. For the rigid body physics simulation aspect of the game, we have decided to implement cardboard boxes in the boss stages. They can be interacted with to block the spiders. We also have an interactive power handle. The mouse (player) has to pull it down by coming near it and pressing the enter button so that the mouse can get transported to the top of the cabinet.
6. We have Game Feel in our responsive controls for the mouse, as well as background music (for both the normal stage and the death scenes). We also have sound effects for some actions, like pulling on the power handle when the mouse is close enough.
7. During gameplay, the player has to avoid hitting the cockroaches, the mouse traps, and somehow find a way to get to the cheese. There are multiple ways to get there, and the mouse has to be able to choose the best way without dying. When facing a cockroach or other enemy, the player has two choices: shoot the enemy, or run away/avoid it.
8. We do have a menu and a death screen that takes players back to the main menu, as well as an in-game display of how many lives are left and a menu that gets triggered when the 'Escape' key is pressed.
9. For inverse kinematics, when the player uses the power handle the mouse will reach towards and look at the box.

Known Problem Areas/Requirements that don't fully work as of yet: One animation that might be hard to see is that if the mouse gets close enough to the power handle, and then the player presses the 'Enter' key, the power handle will come down and make a sound. The animations for the player need to be adjusted a little more because there is a little bit of sliding and some timing issues.

External Assets: A lot of the materials (the wood, countertops, metal), as well as the objects (power handle, sink faucet), have been imported and downloaded from free sites online. The materials are being used as obstacles/steps the mouse has to take care of before getting the cheese and finishing the stage. The model for the mouse is an external asset and the animations for it were taken from another source. The cockroach and the spider are also external assets. There is a transition manager that is taken from the Unity asset store.

Non-standard build dependencies: None

Which files authored by which teammate(s):
1. Who on the team did what?
	- Nandini: I created most of the environment for Stage 1 (the entire room, cabinets, tables, chairs, mats, paintings, stools, etc.). I also added in and worked on a bunch of the materials we use for some of the items (wood, tile, metal, granite), and added in some of the items the mouse can interact with (the power handle, power socket, sink, faucet). I worked on the functionality and animation for the power handle as well, and some of the sounds (added and edited sound effects for power box (had to cut the audio to fit the time that the power box’s handle moves)). I added teleportation features for some of the mouseholes, fixed the colliders on the sink so that the mouse can’t pass through the sink, added an instructions page between the Main Menu and Stage 1, so that the player has a basic idea of what to do, and put a ceiling and directional lighting in both Stage 1 and the Boss stage.
	- Amber: I made the base for the start screen and pause menu. I also rigged the mouse model, configured the avatar, and customized the muscle constraints. I created the AnimatorController for the player and connected the variables, animations, and footstep sounds. I added the models and animations for the cockraoch and spiders. I implemented the 3 lives system and the in-game UI elements, the camera rotation, and the spider AI. I added the inverse kinematics and the camera intro. 
	- Owen: Sounds: (music for menus, levels, and SFX (cheesePickup, mousetrap, and projectile)), Scenes: Made "Death Screen" with it's buttons and music, AI: created logic for the cockroaches to go between different waypoints, Mouse Holes: made these teleport the player to different locations on the map, Level One design: created document that showed how the level should flow (enemies, layout, and win condition), play testing, debugging and fixing different parts of the game
	- Sean: I worked on the main character control code, the the bullets and the death of the main character. I also did the collision for the bullet to the cock roach to destroy that. I created the space for the bullet to come from and the pick up object so people could use the bullets. I fixed some bugs regarding the cockroach AI. Made the transition screen from stage 1 to boss. I also added cups for an interactive environment. Added collision to the powerbox and changed some scripts, so once at the boss stage you didn't have to restart from the beginning.
	- Tanner: I made the boss environment. I added the ability for the spider AI to target the player. I also designed the boss fight itself and added checks to the exit to make sure the fight was over. I added obstacles in the form of cobwebs that slow down the player. I designated one of the Spider enemies as a patrol enemy. This means that it will start out walking between two points, but if the player gets close enough, the spider will begin to chase them.


2. For each team member, list each asset implemented.
	- Nandini: Power handle animations, most of the items (sink, power handle, refrigerator, paintings, stools, etc.) + colliders in Stage 1, lighting.
	- Amber: Player (mouse model, animations, controller), spider, cheese prefab, camera movement, hearts, inverse kinematics
	- Owen: Mouse Trap: animations for it, sound, logic for getting hit by it
	- Sean: I implemented the Cups, Bullet, PickUpObj, and camera.
	- Tanner: Cobweb, books, boxes, SpiderTracker text object


3. Make sure to list C# script files individually so we can confirm each team member contributed to code writing.
	- Nandini: PowerHandleScript.cs, SceneChanger.cs, SceneChangerNew.cs, Mousehole.cs
	- Amber: InGamePauseMenu, LifeTracker, MainCameraController, RotatingHearts, SpiderController, IKControl, IntroDollyCam, + small changes to other scripts to set the animator or player
	- Owen: Cockroach.cs, MouseHole.cs, MouseTrap.cs, Floor.cs, faucet.cs + changes to other's code when debugging 
  	- Sean: Collectable.cs, Collector.cs, Floor.cs, Floordeath.cs, RoachCollision.cs, RoachDeath.cs, PlayerController.cs, LaunchProjectile.cs, SceneChanger1.cs, plus small changes to other scripts.
	- Tanner: Exit, FightManager, SpiderCollision, Cobweb, SpiderController changes, SpiderPatrolController, Spider Tracker