using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class imageSubscriber4TopicPose : UnitySubscriber<MessageTypes.Geometry.PoseStamped>
    {
        /* 
        pose: 
           position: 
             x: 0.0
             y: 0.0
             z: 0.0
           orientation: 
             x: 0.0
             y: 0.0
             z: 0.0
             w: 0.0
        */

        public Vector3 Position;
        public Vector4 Quaternion;
        private float Point_x, Point_y, Point_z;
	private float Quaternion_x, Quaternion_y, Quaternion_z, Quaternion_w; 
        private bool isMessageReceived;

        protected override void Start()
        {
			base.Start();
		}
		
        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(MessageTypes.Geometry.PoseStamped message)
        {
            Point_x = (float)(message.pose.position.x);
	        Point_y = (float)(message.pose.position.y);
            Point_z = (float)(message.pose.position.z);
            Quaternion_x = (float)(message.pose.orientation.x);
            Quaternion_y = (float)(message.pose.orientation.y);
            Quaternion_z = (float)(message.pose.orientation.z);
            Quaternion_w = (float)(message.pose.orientation.w);

            Position = new Vector3(Point_x, Point_y, Point_z);
	        Quaternion = new Vector4(Quaternion_x, Quaternion_y, Quaternion_z, Quaternion_w);

            isMessageReceived = true;
        }

        private void ProcessMessage() {}
	
    }
}


