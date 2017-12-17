using ROSBridgeLib;
using UnityEngine;

public class ROSController : MonoBehaviour
{
    private ROSBridgeWebSocketConnection ros = null;

    void Start()
    {
        // Where the rosbridge instance is running, could be localhost, or some external IP
        ros = new ROSBridgeWebSocketConnection("ws://localhost", 9090);

        // Add subscribers and publishers (if any)
        ros.AddSubscriber(typeof(BallPoseSubscriber));
        ros.AddPublisher(typeof(BallControlPublisher));

        // Fire up the subscriber(s) and publisher(s)
        ros.Connect();
    }

    // Extremely important to disconnect from ROS, otherwise packets continue to flow
    void OnApplicationQuit()
    {
        if (ros != null)
        {
            ros.Disconnect();
        }
    }

    // Update is called once per frame in Unity
    void Update()
    {
        ros.Render();
    }
}
