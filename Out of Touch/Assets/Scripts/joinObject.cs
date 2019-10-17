using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joinObject : MonoBehaviour
{
    public bool carrying;
    public float range = 5;
    public GameObject target;
    public GameObject grabbyHand;


   // public Joystick joystick;
   // public float veloRate = 4.0f;

    // public Button grabButton;


    void Start()
    {
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       if (carrying == false)
        {
             //if ((guide.transform.position - transform.position).sqrMagnitude < range * range)
            if (grabbyHand.transform.position.x - target.transform.position.x <= range)
            {
                carrying = true;
                Debug.Log("dragged");
                makeConnection();


            }
        }
    }

       public void makeConnection() {

            this.GetComponent<Rigidbody>().mass = 1;
           // this.GetComponent<Rigidbody>().velocity = new Vector3(joystick.Horizontal * veloRate, this.GetComponent<Rigidbody>().velocity.y, joystick.Vertical * veloRate);
            this.gameObject.AddComponent<FixedJoint>();
            this.GetComponent<FixedJoint>().connectedBody = GameObject.Find("PlaceHolderPlayer (3)").GetComponent<Rigidbody>();
            //this.GetComponent<FixedJoint>().connectedBody = GameObject.Find("Cube(1)").GetComponent<Rigidbody>();
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
        

        //this.transform.position = grabbyHand.transform.position;
        //this.transform.rotation = guide.transform.rotation;

    }
       /* else if (carrying == true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                //drop();
                carrying = false;
                Debug.Log("not dragged");
                this.GetComponent<Rigidbody>().mass = 1000;
                Destroy(this.gameObject.GetComponent<FixedJoint>());
            }
        }*/
    }

