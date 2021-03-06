# iOS touch input stuttering
Noticable frame jumps and frame freezes on ios with simple touch input

* [Recordings 240 FPS](https://youtu.be/O4JOB5Gsa6I)
* [Introduction Video](https://youtu.be/2lu996QHSpE)
* [Raw video data](https://drive.google.com/drive/folders/0ByTO3RP9DQI0bjl5WklWbVJrZkU?usp=sharing)

## Project information

### Problem

* Triggering the event system with touches on a dummy button creates frame problems
* The frame problems are either Frame freezes or frame Jumps
* boh of them are quite subtle, but noticable once you're trained to see them
* Frame Jumps (leaving out one frame) seems to be more common than frame freezes (in Unity 5.6 at least)
* Most significant problems on iPad Pro
* On GLES3 the problem seems to be less frequent than on Metal

### Test Scenario
* Unity 5.6.0f2
* XCode 8.3 (8E162)
* OpenGLES2, OpenGLES3 and Metal graphics API
* il2CPP
* Gamma color space

![Screenshot v0.2](https://i.imgur.com/f50pAdR.png)

### Results (v0.2)

Lost frames - (Without Tapping / With Tapping)

|                | Metal+Xcode      | Metal           |
|----------------|------------------|-----------------|
| iPad Pro       | (0.472 / 6.850)  | (1.519 / 3.997) |
| iPhone SE      | (0.223 / 0.8135) | (0.234 / 0.800) |
| iPhone 6s Plus | (0.403 / 1.943)  | (0.465 / 1.053) |

### Additional Tests
* Tested with Unity 5.5.1p1
* Tested with XCode 8.2.1, 8.3 beta 2

## How to reproduce?

* Clone the project
* set Build Target to iOS and release, disable development build
* Build & Run Project
* Install the app
* Detach the device from the computer
* Run once without hitting the **Tap!** button
* Run once with hitting the **Tap!** approximately twice a second
* Calculate the difference between the two outcomes
