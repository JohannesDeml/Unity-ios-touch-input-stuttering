# Unity-ios-touch-input-stuttering
Bug report for frame jumps and frame freezes on ios with simple touch input

* [Introduction Video](https://youtu.be/2lu996QHSpE)
* [Recordings 240 FPS](https://youtu.be/O4JOB5Gsa6I)
* [Raw video data](https://drive.google.com/drive/folders/0ByTO3RP9DQI0bjl5WklWbVJrZkU?usp=sharing)

## Project information

### Problem

* Triggering the event system with touches on a dummy button creates frame problems
* The frame problems are either Frame freezes or frame Jumps
* boh of them are quite subtle, but noticable once you're trained to see them
* Frame Jumps (leaving out one frame) seems to be more common than frame freezes (in Unity 5.6 at least)
* Most significant problems on iPad Pro

### Versions
* Tested with Unity 5.5.1p1 and 5.6.0f2
* Tested with XCode 8.2.1 and 8.3 beta 2

### Tested Devices
* iPad Pro
* iPhone 6s
* iPhone SE


## How to reproduce?

* Clone the project
* set Build Target to iOS, rlease and not development build
* Install the app
* Hit the do nothing key until you see stuttering
* when the cube and sphere are out of sight you can press the red button to reset their position
* Especially on iPad Pro we found the stuttering quite fast, but it takes some patience and concentration to find them
