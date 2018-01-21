using UnityEngine;
using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.std_msgs;

public class ROSController : MonoBehaviour
{
	// ros bridge websocket connection parameter
	private ROSBridgeWebSocketConnection ros = null;

	// game object for the player
	public GameObject player;

	// player controller script
	public PlayerController playerController;

	// it is called once the object is active
	void Start()
	{
		// connect to the rosbridge instance, default are: localhost & 9090
		ros = new ROSBridgeWebSocketConnection("ws://localhost", 9090);

		// add subscribers and publishers 
		ros.AddSubscriber(typeof(BallSpeedSubscriber));
		ros.AddPublisher(typeof(BallPosePublisher));

		// fire up the subscriber(s) and publisher(s)
		ros.Connect();
	}

	// it is called once the object is deactivated
	void OnApplicationQuit()
	{
		// it is important to disconnect from ROS, otherwise packets continue to flow
		if(ros != null)
		{
			ros.Disconnect();
		}
	}

	// it is called every frame update
	void Update()
	{
		// render the ros communication
		ros.Render();

		// get the player object position
		double playerPosX = player.transform.position.x;
		double playerPosY = player.transform.position.y;
		double playerPosZ = player.transform.position.z;

		// get the player position vector
		Vector3Msg playerPositionVector = new Vector3Msg(playerPosX, playerPosY, playerPosZ);
		// get the player rotation vector
		Vector3Msg playerRotationVector = new Vector3Msg(0, 0, 0);

		// get the twist message for the player pose
		TwistMsg playerPoseMsg = new TwistMsg(playerPositionVector, playerRotationVector);

		// publish the message
		ros.Publish(BallPosePublisher.GetMessageTopic(), playerPoseMsg);

		// get player speed
		float playerSpeed = (float)BallSpeedSubscriber.playerSpeed;

		// update player speed
		playerController.speed = (playerSpeed == 0)? 1 : playerSpeed;
	}

}
