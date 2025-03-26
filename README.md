# KolkRogue
A rogue like engine I tried to make in 2019

## 2025 revived

Current plan is to use this to learn OOP.<br>
The plan is eventually to be able to give this a map file (txt) and sceneario (json)<br>
the engine would load these 2 and would be a game.<br>
the map file would be just walls and floor, the json would be items players location, his stats, enemies and everything else.<br>
Inventory and AI are gonna be a mess, also a lot of the current code just need to be rewritten.<br>
I'm just rambling, honestly I want to write this for fun.

## old

My main goal was to load a txt file map into array of arrays<br>
find where the player @ is and let him walkaround<br>
but in the end walking around was way too slow<br>
so I wrote that the game wont reaload the whole map<br>
but use cursor and only replace the chars graphically but check the colisions in the real array<br>
this was all pre .NET CORE 3.0<br>
after .NET CORE 3.0 even reloading the whole map is already fast enough<br>

This has never turned out to be a whole game, or usable engine

if I want to ever continue this I'll rewrite it in python 3

lvl1.txt - made by me<br>
lvl2.txt - made by my sister<br>
lvl3.txt - made by my friend but I don't remember who<br>
