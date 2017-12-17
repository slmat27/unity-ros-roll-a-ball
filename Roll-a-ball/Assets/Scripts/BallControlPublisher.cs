using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using SimpleJSON;

public class BallControlPublisher : ROSBridgePublisher
{
    // The following three functions are important
    public new static string GetMessageTopic()
    {
        return "/topic/to/publish/to";
    }

    public new static string GetMessageType()
    {
        return "std_msgs/TwistMsg";
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
