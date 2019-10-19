using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newJoyRight : MonoBehaviour
{
    public Joystick joystick;
    //public Joybutton joybutton;

    public float veloRate = 4.0f;  // better at 8, change in inspector

    //public FixedTouchField TouchField;
    //public float CameraAngle;

   // public float CameraAngleSpeed = 0.2f;

    public Rigidbody myRb;

    private Vector3 CamForward;
    private Transform mainCam;

    private Vector3 rightDirection;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.transform;

        myRb = GetComponent<Rigidbody>();
        //joystick = FindObjectOfType<Joystick>();
        //joybutton = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        // calculate camera relative direction
        CamForward = Vector3.Scale(mainCam.forward, new Vector3(1, 0, 1)).normalized;

        rightDirection = joystick.Vertical * CamForward + joystick.Horizontal * mainCam.right;

        //myRb.velocity = new Vector3(joystick.Horizontal * veloRate, myRb.velocity.y, joystick.Vertical * veloRate);

        // forward movement relative to camera direction

        myRb.velocity = rightDirection * veloRate;

        //camera swipe

        //CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;

        //Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 12, -18);
        //Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);


    }
}
