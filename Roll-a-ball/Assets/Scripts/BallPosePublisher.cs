using SimpleJSON;
using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;

public class BallPosePublisher : ROSBridgePublisher
{
    public new static string GetMessageTopic()
    {
		return "player_pose";
    }

    public new static string GetMessageType()
    {
		return "geometry_msgs/Twist";
    }

    public static string ToYAMLString(TwistMsg msg)
    {
        return msg.ToYAMLString();
    }

    public static ROSBridgeMsg ParseMessage(JSONNode msg)
    {
        return new TwistMsg(msg);
    }
}
