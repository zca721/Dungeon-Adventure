<img src="https://arthive.com/res/media/img/oy1000/work/ec2/28216@2x.webp" width="300" height="400" />
<sup> Artwork by Boris Vallejo: Conan </sup>

Dungeon Adventure
=====
#### Course Project | TCSS 360A | University of Washington Tacoma
### About:
- Tom Capaul wants us to create a dungeon adventure game for our course project
- 2D top down pixel art dungeon adventure game in Unity with VSCode and C#
- Self created sprite images using GIMP
- Followed this video by Chris' Tutorials to setup Barbarian character and mock dungeon
  - https://www.youtube.com/watch?v=7iYWpzL9GkM&list=LL&index=58
- Followed this video by Chris' Tutorials to setup Demon monster and all of its attributes
  - https://www.youtube.com/watch?v=8rTK68omQow
- Followed this series by Sunny Valley Studio to create randomly generated dungeon
  - https://www.youtube.com/playlist?list=PLcRSafycjWFenI87z7uZHFv6cUG2Tzu9v

### Creator:
*Zachary Anderson*

## Iteration 4:
#### Issues:
- Was having issues with the dungeon tile being painted for my simple random walk algorithm, the tiles were being painted over the top of each other. I changed the size of the sprite images in Unity from 100 to 64, which means the tiles were being represented as 100x100 when there actual sizes are 64x64. Then, I had to change the grid size from 0.16 which was recommended by the Chris' Tutorials video, to 1, which would paint the tiles in the whole grid block rather then overlap.
- When placing the proper walls for the randomly created dungeon, there were two instances where the binary representation of a corner wall was not accounted for because there was no floor tile at a diagonal angle and was assigning it as a 4-bit binary number rather then an 8-bit binary number which is required to place corner tiles, so I created two special cases for the two 4-bit binary numbers '1100' and '1001' to place the two specific corner walls.

## Iteration 5:
#### Issues:
- After implementing my DamageableCharacter class that inherets from my IDamagable interface, my death animation for my Demon monster was not working properly. But I realized that I changed the name of the method that deletes a game object and had the wrong even happening when the death animation finished.
- The tutorial I follewed to setup the Demon monster did not show how to transition from idle animation to moving animation for the Demon monster, but I figured out how to use the SetBool action on my Demon monster so when the Demon monster was moving the isMoving action would be true, thus transition from idle to move, and vice versa when the Demon monster no longer isMoving.
- The tutorial I follewed to setup the Demon monster did not show how to make the Demon monster look left and right when chasing the Barbarian character. But I figured out that I could use the calculation for when the Demon monster should move towards the Barbarian character when detected, and when x < 0 it looks left and if x > 0 it looks right.
