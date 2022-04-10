
Helicopter Movement Readme File...!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!



- User able to move helicopter by touch drag.
- It's implemented in touch detector script

Assets\Scripts\TouchDetector.cs

- Player helicopter is still and just rotating according to drag but emvirnment is moving and giving helicopoter movement realistic effect.
- Environment movement is implemented in Touch Detector

Assets\Scripts\TouchDetector.cs

- Player detecting enemies by outo raycasting in Enemy Detector Script

Assets\Scripts\EnemyDetector.cs

- Bullets are pooling in bullet Script, it's fire movement implemented in that well.

Assets\Scripts\Bullet.cs

- Enemy pooling is implemented in Enemy Script and Enemy hiding after bullet fire in that as well.

Assets\Scripts\Enemy.cs


- When the Enemy detected its send response to player and in player script, player send message with target to bullet to fire on it.

Assets\Scripts\Player.cs

- In most used scripts defines the count of bullets for pooling that is used in player script .
