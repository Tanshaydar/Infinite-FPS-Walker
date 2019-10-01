# Infinite FPS Walker

A demo project to demonstrate infinite runner concept in Unity.
Was created in one evening using existing assets and with minimal yet maintainable and extensible code.

![](https://media.giphy.com/media/W4odpAgUi2Lhv0xts5/giphy.gif)

## Gameplay
This is a very basic infinite runner example, so gameplay is pretty simple:
* Use A & D (or ← & →) from keyboard to switch lanes
* In order to make this little game more engaging, you have to keep pressing left or right key to keep in the respective lane, the moment you stop pressing left or right key, you switch back to center lane
* Use W (or ↑) to speed up, in case you feel it is not challenging
* Use S (or ↓) to slow down, in case you feel it is a little bit challenging
* Avoid obstacles, and try to pick up as many as flashlights possible
* Use Options menu to set your graphic settings (quality, resolution, fullscreen etc.)
* Hands are used as visual distractors, or jumpscares if you will, and does not affect player. Bloody screen effect was going to be implemented but I didn't want to push the deadline

## Playable Build
Playable build is Builds/InfiniteFPSWalker.zip file, download and extract.

## Architecture
* This project is made with Unity 2019.2.7, w/ Plus Subscription
* Project Rider is used as IDE
* Build is taken with IL2CPP instead of Mono backend
* Code structure is very simple, yet maintainable and extensible
* There is no highscore system, or save system, or character/level customization
* PostProcess Stack v2 is used from Package Manager to deliver better visuals
* For better performance, lightmaps are baked into prefabs (see Assets)
* Scriptable Objects or higher structures are not used, only basic lists
* A very simple pooling system takes place to generate an infinite track
* Unity's transform limits are not taken into consideration, nor is it expected anyone to keep play until hitting such a structure
* Trigger areas are used instead of event based system, but as a result Update and FixedUpdate function usage is minimal
* A main menu for starting the game, exiting the game, and setting the visual quality is present in main menu scene
* Game takes place in GameScene, alongside with visual indicators and a pause menu, as well as a game over menu
* No texture offset is used, everything is Standard shader, and no shader or texture is accessed by scripts
* Hand animation is done manually inside Unity, using animation tool w/ Mecanim

## Assets
* Royalty Free Horror Ambient Sound: https://www.youtube.com/watch?v=paRR1vXGgck
* Royalty Free Hand Model: https://www.turbosquid.com/FullPreview/Index.cfm/ID/932376
* Item pickup sound is from Silent Hill 2 menuitem menu sound: https://www.youtube.com/watch?v=ULvXc1EgY20
* Hospital Environment: https://assetstore.unity.com/packages/3d/environments/urban/he-abandoned-hospital-v-1-22030 [This uses three models from the package which I bought back in time]
* Prefab Lightmap Baker: https://software.intel.com/en-us/articles/code-sample-lightmapping-code-for-prefabs-in-unity