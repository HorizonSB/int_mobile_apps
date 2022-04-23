using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Rigidbody camera_controller;
    //[SerializeField] private GameObject camera_controller;

    [SerializeField] private FixedJoystick joystick;

    [SerializeField] private float movement_speed;

    private void FixedUpdate()
    {
        camera_controller.velocity = new Vector3(joystick.Horizontal * movement_speed, camera_controller.velocity.y, joystick.Vertical * movement_speed);
        //camera_controller.transform.position = new Vector3(joystick.Horizontal * movement_speed, camera_controller.transform.position.y, joystick.Vertical * movement_speed);
    }
}
