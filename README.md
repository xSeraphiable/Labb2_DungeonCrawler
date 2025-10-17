<h1>What is this?</h1>
This project was created as my second assignment at IT-högskolan, about five weeks into learning C#.  
<br>We had 2.5 weeks to build a simple Dungeon Crawler game. 

<br>Instead of procedural generation, the game uses a predefined map (Level1.txt) containing walls, enemies, and a player start position.
<br>The focus of the project was on object-oriented programming — each entity (player, enemies, walls) manages its own data and behavior.

<h2>Details</h2>
The environment is displayed within a ±5 tile range.  
Walls that have been discovered remain visible, while enemies disappear if they move outside this range.

The game is turn-based.  
Rats move randomly and attack the player if they end up on the same tile, while snakes flee from the player when within 2 tiles.  
Enemies do not attack each other.

Both the player and enemies have a set of dice and a modifier that determine their attacks.  
When a character is attacked, they roll their defence dice and take any remaining damage.

<br><br>
<img width="269" height="127" alt="menu" src="https://github.com/user-attachments/assets/20c5b6a7-6227-4967-8e7d-29087b7df2b6" />
<br><br>
<img width="648" height="313" alt="Skärmbild 2025-10-17 120052" src="https://github.com/user-attachments/assets/918bd54c-0bd7-4579-bf6a-68fb59b6aacc" />
<br><br>


<h2>Tools & Technologies</h2>
<ul>
  <li>C#</li>
  <li>.NET</li>
  <li>Visual Studio</li>
  <li>Git & GitHub</li>
  <li>Object-Oriented Programming (OOP)</li>
  <li>Console Application</li>
</ul>
