# Reference
[.py file template](https://mega.nz/#!dsQ01CYa!llVkuQ-JhW9SlOwNBHMlKuv215Mks-DX1BO2g8hqdsg)

# Some commands
```
Building your nodes:
~$ cd ~/catkin_ws
~$ catkin_make

RUN ROS NODE:
~$ cd ~/catkin_ws
~$ catkin_make
~$ source ./devel/setup.bash
~$ rosrun test_tutorial vptalker.py

Using rqt_graph:
~$ rosrun rqt_graph rqt_graph

#Run WEB socket
~$ roslaunch rosbridge_server rosbridge_websocket.launch

EDITAR bashrc
~$ gedit ~/.bashrc
~$ source ~/.bashrc
```

# Results output from vptalker.py
```
=============== Process img1.jpg!! ======================
vanishing points estimation!Elapsed time is 1.223450 seconds.
[INFO] [1599872656.425877]: SEND DATA: 
layout: 
  dim: []
  data_offset: 0
data: [377.28840631189, 4324.009944843236, 1806.107027168422, 59.61540040345132, 71.28573209106662, 142.69580973505214]
=============== Process img2.jpg!! ======================
vanishing points estimation!Elapsed time is 185.775851 seconds.
[INFO] [1599872842.492039]: SEND DATA: 
layout: 
  dim: []
  data_offset: 0
data: [575.1458786956055, 18010.00421672718, -614.9066180011519, 358.3569596010501, 1122.6814177499753, 334.71572046034413]
=============== Process img3.jpg!! ======================
vanishing points estimation!Elapsed time is 0.145841 seconds.
[INFO] [1599872842.664846]: SEND DATA: 
layout: 
  dim: []
  data_offset: 0
data: [221.68689523499995, 1805.7067124476248, 777.5101650162076, 76.71264483640637, -188.36179936077357, 22.598171081523425]
=============== Process img4.jpg!! ======================
vanishing points estimation!Elapsed time is 0.293116 seconds.
[INFO] [1599872843.726798]: SEND DATA: 
layout: 
  dim: []
  data_offset: 0
data: [445.6394207573726, 12445.753285607823, -5394.22783697032, 226.23142029276147, 507.48715265171705, 134.92269794961558]
=============== Process img5.jpg!! ======================
vanishing points estimation!Elapsed time is 0.547426 seconds.
[INFO] [1599872844.326442]: SEND DATA: 
layout: 
  dim: []
  data_offset: 0
data: [286.2126515343997, 3485.6633168832577, -1064.5787881606936, 108.00000000000001, 494.09132552977286, 74.0]
```
