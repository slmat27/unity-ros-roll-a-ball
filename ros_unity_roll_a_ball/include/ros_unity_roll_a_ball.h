#ifndef ROS_UNITY_ROLL_A_BALL_H
#define ROS_UNITY_ROLL_A_BALL_H

/*******************************************************************/
/* ROS libraries */
#include <ros/ros.h>
#include <std_msgs/Float32.h>
#include <geometry_msgs/Twist.h>

/* libraries */

/*******************************************************************/

class ROS_UNITY_ROLL_A_BALL
{
public:
  /* constructor of the node */
  ROS_UNITY_ROLL_A_BALL(int argc, char** argv);
  /* destructor of the node */
  ~ROS_UNITY_ROLL_A_BALL();
  /* run the node */
  void run();

private:
  /* arguments count & vector */
  int argc_;
  char** argv_;

  /* ROS parameters */
  ros::NodeHandle nh_;
  ros::NodeHandle public_nh_;

  /* ROS publishers */
  ros::Publisher player_speed_pub_;

  /* ROS subscribers */
  ros::Subscriber player_pose_sub_;

  /* flag for debugging printing */
  bool debug_flag_;

  /* player speed parameter */
  float player_speed_;

  /* player pose parameter */
  geometry_msgs::Twist player_pose_;

  /* debug printing message */
  void debugPrint(std::string deubg_message);

  /* callback update for the player pose message */
  void playerPoseCallback(const geometry_msgs::TwistPtr player_pose_msg);
};

#endif /* ROS_UNITY_ROLL_A_BALL_H */
