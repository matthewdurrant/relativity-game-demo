# Relativity Trading Game Demo
![image](https://github.com/matthewdurrant/relativity-game-demo/assets/20775366/bb866748-448b-4b25-a4bf-de8de4937f61)
![image](https://github.com/matthewdurrant/relativity-game-demo/assets/20775366/6e4e5b6c-e91c-4fce-9a8f-02ee85f0317c)

## What is it?
Trading games are one of the oldest video game genres, going back as far as Star Trader in 1974. They are not complicated to implement and don't need amazing graphics, but the core gameplay loop of finding arbitrage - buying cheap, transporting product, and selling high - can be very gripping, and is extremely flexible and extensible (random events, RPG stats, simulating a spaceship, adding a visual novel storyline, etc.). 

A lot of games I've been playing recently (e.g. *Baldur's Gate 3*, *Tears of the Kingdom*) have included shops and trading, but it struck me how weird the economies are. In the game world there might be thousands of swords and daggers scattered around in boxes, but a sword seller will only accept 100 gold for a sword, even though anyone who needs a sword can just go digging through a crate. A one-of-a-kind mushroom that turns you invisible might cost 5 gold, on the other hand. And that sword seller will accept anything with value, no matter how useless, so that the sword seller will happily take 100 rat tails (worth 1 gp each) from the cunning adventurer who wants a sword.

Pondering on this, I got interested in the economics of trading and bartering. I thought it might be interesting to simulate a basic economy in a game, with actual supply and demand - where the sword seller will pay more for iron than the grocer, and the grocer will buy as many tomatoes from you as she can sell, but no more.

Also, because simulating an economy didn't feel big enough, I thought it'd be fun to implement the Lorentz factor and calculate time dilation.

## What's in this demo?
The game is non-existent at the moment, but there is an interface to calculate time dilation for relativistic travel. You can enter your year of birth, the distance of your journey, and how fast your spaceship goes, and find out how much time will pass (for you and for a stationary observer) and how old you'll be in real years and in calendar years. For extra fun, you can enter a speed value higher than 1c (i.e. faster-than-light) and boggle at the mathematical reality that *you will go back in time*, possibly becoming your own grandfather.

## What's next?
Well, everything:
- a star map with star coordinates (on a 2D plane, or even a 3D plane?) with actual vectors and such to calculate distance in a 2D or 3D space
- things to trade
- spaceships to buy/tweak
- people, who get born, pair off, have children, and die while you stay young
- simulating an entire economy (no biggie)

## The physics of relativistic travel
### The human factor
Your ship plants itself on the soil of the first human colony around the star Wolf 1069, 31.2 light years from Earth. As you offload your cargo of food and machine parts, you get chatting to young Tyx, barely 20, one of the first native-born Wolfians. You share a box of beers under the Wolfian sky, singing songs, searching out the distant light of Sol, waiting for the twin moons to rise, sharing your hopes and fears and dreams.

As you leave, Tyx asks: "Could you bring me some Earth soil next time you're in the system? I want to know where we came from."

"No problem," you reply. "I'm just about to make a round trip there. I'll be back next year."

You take off in your ship and hurtle towards earth at 0.9998c, a pretty normal cruise speed for your craft. On Earth, you scoop some soil into a plastic container, get back into your ship and set a course back to Wolf 1069. Crossing the 31.2 light years, your ship's clock marks off 7 months and 17 days. The total trip has taken you a little over 15 months.

On Wolf 1069, the colony is unrecognisable. Massive skyscrapers reach high into the purple-green atmosphere. You can barely understand their language, but after some time with a universal translator, you manage to track down your friend Tyx, in the retirement home. They are 82 years old. You press the plastic container of soil into their hand.

"Is that you, sonny?" Tyx croaks, before dying dramatically, the plastic container falling from their hand Rosebud-style, as the life support machine beeps *(continues in melodramatic style)*

### You can't get then from here
Everything in the universe is travelling at 100% of the speed=of-light. Even you, right now, reading this. You don't notice it, because you're going through time, not space, but you (and me and everyone else) is hurtling uncontrollably into the future at 100% of the speed-of-light, or 1c.

If you move in space, it comes out of that 100% speed-of-light budget. At slow speeds it's barely noticable. But if you are on a spaceship travelling at 0.1c (10% of the speed of light), in the time dimension, you are only travelling at 0.9c (90% of the speed of light) now, compared to your friend on Earth who is not moving (much) but going at 1c through time.

So *your time is shorter than your friend's time*. You could think of it roughly this way: if you are going through space at 10% lightspeed, you are only getting 90% of the time you were getting before. So 100 seconds becomes 90 seconds for you. 100 days for your friend becomes 90 days for you. And so on.

OK, this is not the exact calculation. 100 days would be more like 99.5 days. But you get the idea. The faster you go in space, the more squashed your time gets. This is covered by the Lorentz factor:
γ = 1 / √(1 - v^2/c^2)

In a move that is guaranteed to burst your head, the exact same calculation we use to calculate how time gets squashed *is the exact same calculation we use to calculate how space gets squished* so that a 100 m spaceship becomes a 99.5 m spaceship ... but that's another story.

The Lorentz calculation is not even that difficult and I'm not great at maths. But of course, the outcome is huge, because all our favourite science fiction stories are ruined. But there are lots of interesting ways to explore this phenomenon, from *The Forever War* by Joe Haldeman to the movie *Interstellar* (which was technically about gravitational time dilation), which boil down to *you stay young while everyone else gets old and dies*. So I thought that might make a cheery subject for a video game.
