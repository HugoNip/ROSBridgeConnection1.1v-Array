# Introduction
This project shows how to achieve communication between Unity3D (C#) and Python code by using [ROSbridge](http://wiki.ros.org/rosbridge_suite) in Ubuntu. The source project is written by MATLAB Eigine, so this project also shows how to construct a [communication between Python and MATLAB](https://github.com/Varun-Haris/Vanishing-point-estimation-code).    

ROSbridge provides a JSON API to ROS functionality for non-ROS programs. There are a variety of front ends that interface with rosbridge, including a WebSocket server for web browsers to interact with. Rosbridge_suite is a meta-package containing rosbridge, various front end packages for rosbridge like a WebSocket package, and helper packages. ROSbridge is used based on [ROS#](https://github.com/siemens/ros-sharp).  

![ss1.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss1.png)

# Requirements
1. python2/3   
2. [Unity3D](https://tecrobust.com/unity3d-for-ubuntu-how-to-install-unity3d-on-linux-ubuntu-18-04-lts-19-04-19-10/)   
3. [ROS Kinetic/Melodic](http://wiki.ros.org/ROS/Installation)     
4. [ROS#](https://github.com/siemens/ros-sharp)   
5. [ROSbridge](http://wiki.ros.org/rosbridge_suite)   
6. [MATLAB code](https://github.com/wgchoi/eccv_indoor)   

NOTE: ROS Noetic and Ubuntu 20.04 may be not one of the best way to run this code, because the MATLAB Engine with the latest version, i.e., R2020a, for Python supports Python version 2.7, 3.6, and 3.7, but the version of Python in Ubuntu 20.04 is 3.8. You can open the file with name of "setup.py" for checking. The setup.py file locates in the directory: /usr/local/MATLAB/R2020a/extern/engines/python/. To make MATLAB Eigine supports python, please configure it first by implementing "python/python2/python3 setup.py".    

# Configuration
## Part1: ROS Node as a publisher
### Step1: [Create a new package](http://wiki.ros.org/ROS/Tutorials/CreatingPackage) in catkin workspace
```
~$ cd ~/catkin_ws/src
~$ catkin_create_pkg test_tutorial std_msgs rospy roscpp
~$ cd ~/catkin_ws
~$ catkin_make
```
### Step2: Move the .py file into src directory, change its Permissions
```
~$ sudo mv /path/to/file/vptalker.py /path/to/catkin_ws/src/test_tutorial/src/
```
![ss11.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss11.png)

### Step3: Change paths in the .py file
![ss12.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss12.png)

## Part2: Unity3D Node as a subscriber
### Step1: Create a new Unity3D Scene, and create the RosConnector4Unity3D (empty GameObject)
![ss3.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss3.png)

### Step2: Add [RosSharp](https://github.com/siemens/ros-sharp/tree/master/Unity3D/Assets) into Unity3D Assets directory
![ss4.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss4.png)

#### ROS Bridge Client has added into Unity3D successfully
![ss17.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss17.png)

### Step3: Move VpDataSubscriber.cs into [RosCommuncation](https://github.com/siemens/ros-sharp/tree/master/Unity3D/Assets/RosSharp/Scripts/RosBridgeClient/RosCommuncation) directory
![ss5.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss5.png)

### Step4: Add components Ros Connector and Vp Data Subscriber for RosConnector4Unity3D 
![ss6.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss6.png)

### Step5: Run WEB socket to get the Ros Bridge Server Url for Ros Connector
```
open a new terminal (do not close it)
~$ roscore

open a new terminal (do not close it)
~$ roslaunch rosbridge_server rosbridge_websocket.launch
```
#### Ros Bridge Server Url: localhost (ROS_MASTER_URI=http://localhost:11311)  
![ss9.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss9.png)


### Step6: Look for the TOPIC NAME in vptalker.py and fill it in Topic of Vp Data Subscriber 
![ss8.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss8.png)

## Part3: Starting communication
### Step1: RUN ROS NODE:
```
cd ~/catkin_ws
catkin_make
source ./devel/setup.bash
rosrun test_tutorial vptalker.py
```

### Step2: Play Unity3D scene and show the results
#### Unity3D panel
![ss13.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss13.png)
#### Terminal
![ss14.png](https://github.com/HugoNip/ROSBridgeConnection1.1v-Array/blob/master/Figure/ss14.png)

# Reference
[C# Script Templates](https://mega.nz/#!dsQ01CYa!llVkuQ-JhW9SlOwNBHMlKuv215Mks-DX1BO2g8hqdsg)    
[Tutorial](https://www.youtube.com/watch?v=lVa_bb0UFMs&ab_channel=bryansgue)    
