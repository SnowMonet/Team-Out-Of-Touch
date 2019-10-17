using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newJoystickControl : MonoBehaviour
{
    public Joystick joystick;
    //public Joybutton joybutton;
   
    public float veloRate = 4.0f;

    public FixedTouchField TouchField;
    public float CameraAngle;
    
    public float CameraAngleSpeed = 0.2f;

    public Rigidbody myRb;

    // Start is called before the first frame update
    void Start()
    {

        myRb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        //joybutton = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        
        myRb.velocity = new Vector3(joystick.Horizontal * veloRate, myRb.velocity.y, joystick.Vertical * veloRate);
  
        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;
       

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 12, -18);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
        

    }
}
