InHouse
=======

A start on a C# front-end for the now-defunct InTrade website.  Inspiration was to develop a user interface
for InTrade similar to that of the in-game Auction House in World of Warcraft.

This was more of a dev toy and learning tool than an actual app, and now that the InTrade website (and API)
is offline, it is completely non-functional, though it may have some value as an example of using the .NET WebClient
class to do simple HTTP GETs and LINQ for wrangling large and fairly complex XML strings.

Build Instructions
------------------
Requires jhblib and Visual Studio 8.  After cloning InHouse:
- clone jhblib (github.com/jbirkel/jhblib)
- open InHouse.sln in VS8
- add existing project jhblib/cslibW32/jhblib-cslibW32.csproj to the solution (from wherever you cloned it to)
- in the InHouse project, add a reference to jhblib-cslibW32 (it will be the only item in the Projects tab of the 'Add Reference' window)
- build and run it
