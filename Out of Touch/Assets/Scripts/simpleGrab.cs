using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleGrab : MonoBehaviour { 

//public float distance = 1f;
//public LayerMask boxMask;

GameObject box;

public GameObject myOriginHolder;
//public GameObject greatGrandChildGrabbyHand;
//public GameObject emptyJointHolder;

public float maxDistance = 5f;

[SerializeField]
private LayerMask layerMask;

bool grabOn = false;

bool grabOff;

public void grabIsOn()
{
    grabOn = true;
}

public void grabIsOff()
{
    grabOff = true;
}

    public void iWannaGrabIt()
    {
        
    }

    // Use this for initialization
    void Start()
{

}

// Update is called once per frame
//void Update()
//{
 //   Raycast();
//}

    public void Raycast()
    {
        Vector3 origin = myOriginHolder.transform.position;
        Vector3 direction = myOriginHolder.transform.forward;

        Debug.DrawRay(origin, direction * maxDistance, Color.red);

        Ray ray = new Ray(origin, direction);

        // RaycastHit hitInfo;
        //Vector3 grabDistance = myOriginHolder.transform.position - raycastHit.collider.gameObject.position;

        if (grabOn && Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance, layerMask) && Input.GetKeyDown(KeyCode.E))

        //if (Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance, layerMask))
          {
            Debug.Log("grab is on");
            raycastHit.collider.GetComponent<Renderer>().material.color = Color.green;
            //box = hit.collider.gameObject;
            box = raycastHit.collider.gameObject;
            box.AddComponent<SpringJoint>();
            box.GetComponent<SpringJoint>().connectedBody = this.GetComponent<Rigidbody>();
           // box.GetComponent<FixedJoint>().enabled = true;
            box.GetComponent<interactableItem>().beingPushed = true;

        }
       else if (Input.GetKeyUp(KeyCode.E))//(grabOff)
        {
            Debug.Log("grab is off");
            //box.GetComponent<FixedJoint>().enabled = false;
            Destroy(box.GetComponent<SpringJoint>());
            box.GetComponent<interactableItem>().beingPushed = false;
        }
    }
}
