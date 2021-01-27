#!/usr/bin/env python
import rospy
from std_msgs.msg import String, Float64MultiArray
from sensor_msgs.msg import Image
from cv_bridge import CvBridge, CvBridgeError
from geometry_msgs.msg import PoseStamped

import numpy as np
import cv2

"""
sensor_msgs/Image keyframe
std_msgs/Float64MultiArray vp_array
geometry_msgs/PoseStamped slam_pose
"""

## Vanishing point estimation library
import lu_vp_detect
from lu_vp_detect import VPDetection

## Custom message
# from orb_slam2_ros.msg import custom

class pose_estimator:
    def __init__(self):
        self.bridge = CvBridge()
        self.pose = PoseStamped()
        rospy.Subscriber("/orb_slam2_mono/keyframes", Image, self.getImage)
        rospy.Subscriber("/orb_slam2_mono/pose", PoseStamped, self.getPose)

        self.vpest = VPDetection(length_thresh=10, focal_length=1855)
        # self.vp_pub = rospy.Publisher("/vp_data", custom, queue_size=10)    # topic name
        self.pose_pub = rospy.Publisher("/pose_data", PoseStamped, queue_size=10)               # topic name
        self.keyframe_pub = rospy.Publisher("/keyframe_data", Image, queue_size=10)             # topic name
        self.vp_pub = rospy.Publisher("/vp_data", Float64MultiArray, queue_size=10)             # topic name        
        # self.message = custom()

    def getPose(self, data):
        self.pose = data

    def getImage(self, data):
        pos_msg = Float64MultiArray()
        try:
            frame = self.bridge.imgmsg_to_cv2(data, "mono8")
            vps = self.vpest.find_vps(frame)
            vp2D = self.vpest.vps_2D

            for vp in vp2D:
                if vp[0] >= 0 and vp[1] >= 0:
                    if vp[0] < frame.shape[0] and vp[1] < frame.shape[1]:
                        pos_msg.data = (vp[0], vp[1])
            """
            self.message.slam_pose = self.pose
            self.message.keyframe = data
            self.message.vp_array = pos_msg
            """
            print("Publishing Custom Message")
            # self.vp_pub.publish(self.message)
            self.pose_pub.publish(self.pose)
            print(self.pose)
            self.keyframe_pub.publish(data)
            self.vp_pub.publish(pos_msg)


        except AttributeError as e:
            print("No image data. Hold on !")

if __name__=='__main__':
    ## Start ROS node
    rospy.init_node("vp", anonymous=False)  # node name
    obj = pose_estimator()
    # print("########### pose: " + str(obj.messge.slam_pose))
    # print("########### data: " + obj.messge.keyframe)
    # print("########### vp_array: " + str(obj.messge.vp_array))
    rospy.spin()
