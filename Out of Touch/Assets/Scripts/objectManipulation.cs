using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectManipulation : MonoBehaviour
{

    public GameObject tempParent;
    public Transform guide;
    bool carrying;
    public float range = 5;
    public GameObject item;

   // public Button grabButton;

        void IgrabbedAnItem()
    {




    }

    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (carrying == false)
        {
            //if (Input.GetKeyDown(KeyCode.K) && (guide.transform.position - transform.position).sqrMagnitude < range * range)
                if ((guide.transform.position - transform.position).sqrMagnitude < range * range)
                {
                //pickup();
                carrying = true;

                Debug.Log("dragged");
                this.GetComponent<Rigidbody>().mass = 1;
                this.gameObject.AddComponent<FixedJoint>();
                //this.GetComponent<FixedJoint>().connectedBody = FindObjectOfType<PlayableCharacter>().GetComponent<RigidBody>();
                this.GetComponent<FixedJoint>().connectedBody = GameObject.Find("Destination").GetComponent<Rigidbody>(); 
            }
        }
        else if (carrying == true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                //drop();
                carrying = false;

                Debug.Log("not dragged");
                this.GetComponent<Rigidbody>().mass = 1000;
                Destroy(this.gameObject.GetComponent<FixedJoint>());
            }
        }
    }
    void pickup()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }
    void drop()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
    }
}
