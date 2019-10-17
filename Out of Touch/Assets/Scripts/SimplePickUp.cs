using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePickUp : MonoBehaviour
{
    public Transform objectIsHere;
    bool isCarrying;

    public void carryingObject()
    {
       // if (isCarrying == false)
       // {

            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = objectIsHere.position;
            this.transform.parent = GameObject.Find("Destination").transform;
            isCarrying = true;

       // }
    }


   public void placingObject()
    {
           // if (isCarrying == true)
           // {

                this.transform.parent = null;
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<Rigidbody>().useGravity = true;
                isCarrying = false;
           // }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCarrying == false)
        {
            carryingObject();
        }


        if (isCarrying == true)
        {
            placingObject();
        }
    }
}
