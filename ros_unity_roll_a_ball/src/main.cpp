#include "ros_unity_roll_a_ball.h"

int main(int argc, char** argv)
{
  ros::init(argc, argv, "ros_unity_roll_a_ball");

  ROS_UNITY_ROLL_A_BALL ros_unity_roll_a_ball(argc, argv);

  ros_unity_roll_a_ball.run();

  return true;
}
