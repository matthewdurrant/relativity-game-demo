# Relativity Trading Game Demo
## What is it?
This project is a roguelike space trading game in the vein of [FTL](https://subsetgames.com/ftl.html), but with a twist - there's no faster-than-light (FTL) travel. Instead, all travel is simulated according to the laws of special relativity, so that a long journey to a distant star might take a hundred years in "realspace" (coordinate time) but only a few months for you.

See the [wiki](https://github.com/matthewdurrant/relativity-game-demo/wiki/) for more musings!

## What's in this demo?
The game is non-existent at the moment, but there is an interface to calculate time dilation for relativistic travel. You can enter your year of birth, the distance of your journey, and how fast your spaceship goes, and find out how much time will pass (for you and for a stationary observer) and how old you'll be in real years and in calendar years. For extra fun, you can enter a speed value higher than 1c (i.e. faster-than-light) and boggle at the mathematical reality that *you will go back in time*, possibly becoming your own grandfather.

## What's next?
Well, everything:
- ~~a star map with star coordinates (on a 2D plane, or even a 3D plane?) with actual vectors and such to calculate distance in a 2D or 3D space~~
- things to trade
- spaceships to buy/tweak
- people, who get born, pair off, have children, and die while you stay young
- simulating an entire economy (no biggie)

## Endgame
This started as just a prototype but the basic gimmick starts to raise all kinds of interesting questions and gameplay elements, e.g.:
- You have to complete a quest before the questgiver dies of old age.
- You have to get back to Earth before _you_ die of old age.
- This time sensitive delivery needs to get to Alpha Centauri in 5 days (proper time).
- You have a cargo hold full of fidget spinners. The fad is dead on Earth but the hicks out on Betelgeuse will go mad for them - in about 100 years.

It would be nice to eventually plug this into a nice game engine as a frontend, so that the 2D terminal is complemented by 3D space, á la [Stories Untold](https://storiesuntoldgame.com/).
