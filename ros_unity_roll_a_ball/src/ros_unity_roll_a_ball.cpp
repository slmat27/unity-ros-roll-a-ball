#include "ros_unity_roll_a_ball.h"

/* constructor of the node */
ROS_UNITY_ROLL_A_BALL::ROS_UNITY_ROLL_A_BALL(int argc, char** argv)
    : argc_(argc), argv_(argv)
{
  ros::NodeHandle public_nh;
  public_nh_ = public_nh;

  ros::NodeHandle private_nh("~");
  nh_ = private_nh;

  // get debugging flag
  public_nh_.getParam("debug_flag", debug_flag_);

  // get the player speed
  public_nh_.getParam("player_speed", player_speed_);
}

/* destructor of the node */
ROS_UNITY_ROLL_A_BALL::~ROS_UNITY_ROLL_A_BALL()
{
  if (ros::isStarted())
  {
    ros::shutdown();
    ros::waitForShutdown();
  }
}

/* callback update for the player pose message */
void ROS_UNITY_ROLL_A_BALL::playerPoseCallback(
    const geometry_msgs::TwistPtr player_pose_msg)
{
  player_pose_.linear.x = player_pose_msg->linear.x;
  player_pose_.linear.y = player_pose_msg->linear.y;
  player_pose_.linear.z = player_pose_msg->linear.z;
}

/* run the node */
void ROS_UNITY_ROLL_A_BALL::run()
{
  debugPrint("Node is running ...");

  // set ROS loop rate to 1Hz
  ros::Rate loop_rate(1.0);
  // loop as long as ROS is ok
  while (ros::ok())
  {
    // subscribe to the player pose published by unity
    player_pose_sub_ = public_nh_.subscribe("player_pose", 1, &ROS_UNITY_ROLL_A_BALL::playerPoseCallback, this);

    // publish the player speed subscribed by unity
    player_speed_pub_ = public_nh_.advertise<std_msgs::Float32>("player_speed", 1);
    std_msgs::Float32 player_speed_msg;
    player_speed_msg.data = player_speed_;
    player_speed_pub_.publish(player_speed_msg);

    ros::spinOnce();
    loop_rate.sleep();
  }
}

/* debug printing message */
void ROS_UNITY_ROLL_A_BALL::debugPrint(std::string deubg_message)
{
  if (debug_flag_)
    std::cout << deubg_message.c_str() << std::endl;
}
