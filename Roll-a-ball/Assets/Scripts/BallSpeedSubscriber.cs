using UnityEngine;
using SimpleJSON;
using ROSBridgeLib;
using ROSBridgeLib.std_msgs;

public class BallSpeedSubscriber : ROSBridgeSubscriber
{
	public static float playerSpeed;

	public new static string GetMessageTopic()
	{
		return "player_speed";
	}

	public new static string GetMessageType()
	{
		return "std_msgs/Float32";
	}

	public new static ROSBridgeMsg ParseMessage(JSONNode msg)
	{
		return new Float32Msg(msg);
	}

	public new static void CallBack(ROSBridgeMsg msg)
	{
		Float32Msg speedMessage = (Float32Msg)msg;

		playerSpeed = speedMessage.GetData();

		Debug.Log("speedMessage: " + playerSpeed);
	}
}

