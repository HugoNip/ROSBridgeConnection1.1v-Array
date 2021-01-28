using UnityEngine;
using UnityEngine.UI;

using RosSharp.RosBridgeClient.MessageTypes.Sensor;

namespace RosSharp.RosBridgeClient
{
    public class imageSubscriber4TopicKeyframe : UnitySubscriber<MessageTypes.Sensor.Image>
    {
        public MessageTypes.Sensor.Image image;
        private bool isMessageReceived;
        private Texture2D texture2D;
        private byte[] imageData;
        private int len, H, W, pixelVal;
        private Color[] colorPixel;

        protected override void Start()
        {
            Debug.Log("Start\n");
            base.Start();

            // public Texture2D(int width, int height);
            /*
            I store the keyframe image data into a byte[] array, and then
            use texture2D type to receive the byte[] array data.
            I think the width and height need to be set correctly, 
            but I don't know how to set because I am not familar with Unity3D
             */
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
            H = (int)image.height;
            W = (int)image.width;
            Debug.Log("height of imageData: " + H);
            Debug.Log("width of imageData: " + W);

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
            Debug.Log("Value checking 3: " + imageData[2073599]);
            
        }

        private void ProcessMessage() {
            
            Debug.Log("ProcessMessage\n");
            isMessageReceived = false;
            
            // Load data into the texture.
            /*
            Texture2D.LoadRawTextureData
            public void LoadRawTextureData(byte[] data);

            there is an issue with size, 
            the height of the imageData is 1, while the width of the imageData is 2073600,
            you can use "Value checking 3" to confirm it.
            I think the texture2D size is as same as imageData size, but I don't know how to 
            reshape it to [1920, 1080]
            you can use other method to receive the imageData, I have set it to byte[] type
            it will be more convinent to use the byte[] type data
            */            
            texture2D.LoadRawTextureData(imageData);
            texture2D.Apply();
            /*
            you can assign texture to renderer's material.
            GetComponent<Renderer>().material.mainTexture = tex; 

            reference: https://docs.unity3d.com/ScriptReference/Texture2D.LoadRawTextureData.html
            */
            //colorPixel = texture2D.GetPixels(0, 8, 1,400);
            // Debug.Log("Value checking 4: " + colorPixel);
        }

    }
}
