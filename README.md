# Introduction
This project shows how to achieve communication between Unity3D (C#) and Python code by using [ROS#](https://github.com/siemens/ros-sharp) in Ubuntu. The source project is written by MATLAB Eigine, so this project also shows how to construct a [communication between Python and MATLAB](https://github.com/Varun-Haris/Vanishing-point-estimation-code).    

![ss1.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss1.png)

# Requirements
1. python2/3   
2. MATLAB    
3. [ROS Kinetic/Melodic](http://wiki.ros.org/ROS/Installation)     
4. [Unity3D](https://tecrobust.com/unity3d-for-ubuntu-how-to-install-unity3d-on-linux-ubuntu-18-04-lts-19-04-19-10/)   
5. [ROSBridge](http://wiki.ros.org/rosbridge_suite)   

NOTE: ROS Noetic and Ubuntu 20.04 may be not one of the best way to run this code, because the MATLAB Engine with the latest version, i.e., R2020a, for Python supports Python version 2.7, 3.6, and 3.7, but the version of Python in Ubuntu 20.04 is 3.8. You can open the file with name of "setup.py" for checking. The setup.py file locates in the directory: /usr/local/MATLAB/R2020a/extern/engines/python/. To make MATLAB Eigine supports python, please configure it first by implementing "python/python2/python3 setup.py".    

# Configuration
## Part1: ROS workspace
### Step1: Create a new package in catkin workspace

### Step2: Add files into directory

### Step3: 

## Part2: Unity3D

## Part3: Starting detection

# Reference
[C# Script Templates](https://mega.nz/#!dsQ01CYa!llVkuQ-JhW9SlOwNBHMlKuv215Mks-DX1BO2g8hqdsg)    
[Tutorial](https://www.youtube.com/watch?v=lVa_bb0UFMs&ab_channel=bryansgue)    
