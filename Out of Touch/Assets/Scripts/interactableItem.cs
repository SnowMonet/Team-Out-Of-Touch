﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableItem : MonoBehaviour{

    public float defaultMass;
    public float imovableMass;
    public bool beingPushed;
    float xPos;

    public Vector3 lastPos;

    public int mode;
    public int colliding;
    // Use this for initialization
    void Start()
    {
        xPos = transform.position.x;
        lastPos = transform.position;
    }

    public void breakConnection()
    {
        Destroy(GetComponent<SpringJoint>());
   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mode == 0)
        {
            if (beingPushed == false)
            {
                transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            }
            else
                xPos = transform.position.x;
        }
        else if (mode == 1)
        {

            if (beingPushed == false)
            {


                GetComponent<Rigidbody>().mass = imovableMass;

            }
            else
            {
               GetComponent<Rigidbody>().mass = defaultMass;
                //	GetComponent<Rigidbody> ().isKinematic = false;
            }

        }
    }


}
