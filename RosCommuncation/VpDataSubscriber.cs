/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class VpDataSubscriber : UnitySubscriber<MessageTypes.Std.Float64MultiArray>
    {
        public Vector2 data1, data2, data3;
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
            data1 = GetData1(message);
            data2 = GetData2(message);
            data3 = GetData3(message);
            isMessageReceived = true;
        }

        private void ProcessMessage()
        {
            /* 
            PublishedTransform.position = position;
            PublishedTransform.rotation = rotation;
             */
        }

        private Vector2 GetData1(MessageTypes.Std.Float64MultiArray message)
        {
            return new Vector2((float)message.data[0], (float)message.data[1]);
        }

        private Vector2 GetData2(MessageTypes.Std.Float64MultiArray message)
        {
            return new Vector2((float)message.data[2], (float)message.data[3]);
        }

        private Vector2 GetData3(MessageTypes.Std.Float64MultiArray message)
        {
            return new Vector2((float)message.data[4], (float)message.data[5]);
        }
    }
}