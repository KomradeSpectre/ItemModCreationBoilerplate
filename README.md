# Item Mod Creation Boilerplate
## What is the item mod creation boilerplate?
The item mod creation boilerplate for Risk of Rain 2 is a visual studio project that allows for an expedient setup of code for the typical item mod for use with R2API. It comes with the following features in the template so you don't have to set them up yourself:

 - -Base Class Files - These act as the central point for classes that inherit from them, and provide code standardization and some helper functionality to their dependents. An example would be the `ItemBase` providing `GetCount` functionality without having to go through a `body/master` to the `inventory` to the `GetItemCount` method and null check the body yourself.

- -Base Type Validation - Checks automatically what classes exist in the mod that inherit from any of the included bases and provides configs for them which the features of vary depending on the base being used.

- Latest R2API and Commonly Used Stubbed Game Assemblies - Included so that you don't have to waste time setting up references to them. Located in a `libs` folder in the project directory.

- Some Helper Functions - Included a few helper functions that address common struggles with setting up items, like the `ItemDisplaySetup` helper method which sets up `RendererInfos` for an `ItemDisplay` . These allow your prefab to properly cloak/disappear or have any overlay that `ItemDisplays` could have depending on the game situation. The debug functionality of it allows you to debug materials ingame of any meshrenderer material that has the `Hopoo Games Deferred Standard`, `Hopoo Games Cloud Intersection Remap`, or `Hopoo Games Cloud Remap` shaders on them.

## How do I use it?
There are a variety of ways you can utilize this boilerplate, but the easiest one would be utilizing the template zip file included in the repo. Place the zip file in `Documents Folder -> Visual Studio 20[xx] -> Templates -> Project Templates` folder and restart Visual Studio. Now when you create a new project, you can search for `Item Mod Creation Boilerplate`. Change whatever name you'd like your project to be on it, set your directory and other settings and enjoy. 


## Special Thanks

**ThinkInvisible**- Most of what I had learned to put this project together came from what I learned from ThinkInvisible's TILER2 api. It's a great API for starters.

**Harb** - Providing additional functionality to this template, like the type search that automatically detects types of any of the bases in this template.
