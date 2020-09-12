#!/usr/bin/env python

import rospy
import matlab.engine
import matlab
from std_msgs.msg import Float64MultiArray

def vptalker():
    eng = matlab.engine.start_matlab()
    codeDir = "/path/to/MATLAB/Code/UIUC_Varsha/SpatialLayout/spatiallayoutcode/"
    imgDir = "/path/to/image/data/" # Image name: img1.jpg, img2.jpg, img3.jpg, img4.jpg, ...
    workDir = "/path/to/result/storage/path/vanishingPoint/"

    ## Start ROS node
    rospy.init_node('vanishingPoint', anonymous=True)
    pub = rospy.Publisher("topicvp", Float64MultiArray, queue_size=10) # TOPIC NAME
    r = rospy.Rate(10)

    ## Adding the path into the python interpreter
    eng.addpath(codeDir, nargout=0)
    eng.addpath(codeDir+"ComputeVP/", nargout=0)
    i = 1

    while not rospy.is_shutdown() and i < 6:
        imageName = "img"+str(i)+".jpg"
        (boxlayout, surface_labels, resizefactor, vpdata) = eng.getspatiallayout(imgDir, imageName, workDir, nargout=4)
        i+=1
        
        pos_msg = Float64MultiArray()
        pos_msg.data = (vpdata['vp'][0][0], vpdata['vp'][0][1], vpdata['vp'][1][0], vpdata['vp'][1][1], vpdata['vp'][2][0], vpdata['vp'][2][1])
        pub.publish(pos_msg)
        rospy.loginfo('SEND DATA: \n%s', pos_msg)

        r.sleep()

if __name__ == '__main__':
    try:
        vptalker()
    except matlab.engine.MatlabExecutionError:
        print("Okay, I think something just went wrong there !")

