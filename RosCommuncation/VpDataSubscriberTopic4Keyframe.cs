using UnityEngine;
using UnityEngine.UI;

using RosSharp.RosBridgeClient.MessageTypes.Sensor;

namespace RosSharp.RosBridgeClient
{
    public class VpDataSubscriberTopic4Keyframe : UnitySubscriber<MessageTypes.Sensor.Image>
    {
        public MessageTypes.Sensor.Image image;
            private bool isMessageReceived;
            private Texture2D texture2D;
            private byte[] imageData;
            private int len;

        protected override void Start()
        {		Debug.Log("Start\n");
                base.Start();

                texture2D = new Texture2D(1, 1);            
        }
            
        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(MessageTypes.Sensor.Image Image)
        {
            Debug.Log("ReceiveMessage\n");
            image = Image;

            isMessageReceived = true;

            imageData = Image.data;	    
            len = imageData.Length;	// 2073600

            /*
            To confirm that the keyframe data has been passed into Unity3, 
            I print the keyframe data.
             */
            Debug.Log("Length of imageData: " + len);
            Debug.Log("Value checking 1: " + imageData[10]);
            Debug.Log("Value checking 2: " + imageData[100]);
            Debug.Log("Value checking 3: " + imageData[1000]);
        }

        private void ProcessMessage() {
            
            Debug.Log("ProcessMessage\n");
            isMessageReceived = false;
            
            // Load data into the texture.
            /*
            I put the keyframe data into texture2D, so you can use this data based on
            the data with type of texture2D
             */
            texture2D.LoadRawTextureData(imageData);
            texture2D.Apply();
        }

    }
}
