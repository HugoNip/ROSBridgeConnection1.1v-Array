using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class VpDataSubscriberTopic4VP : UnitySubscriber<MessageTypes.Std.Float64MultiArray>
    {
        public Vector2 VP_Data;
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

        protected override void ReceiveMessage(MessageTypes.Std.Float64MultiArray message)
        {
            VP_Data = GetData(message);
            isMessageReceived = true;
        }

        private void ProcessMessage() {}

        private Vector2 GetData(MessageTypes.Std.Float64MultiArray message)
        {
            return new Vector2((float)message.data[0], (float)message.data[1]);
        }
    }
}
