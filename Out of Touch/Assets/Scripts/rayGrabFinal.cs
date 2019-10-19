using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayGrabFinal : MonoBehaviour
{
    public GameObject myOriginHolder;
    public GameObject greatGrandChildGrabbyHand;
    public GameObject emptyJointHolder;

    GameObject box;

    public float maxDistance = 5f;

    [SerializeField]
    private LayerMask layerMask;


    void Start()
    {

    }

    public void makeConnection()
    {
        // get hand to move toward object use movetowards
        // once hand reaches a certain distance create new empty at that transform
        // create fixed joint between new empty and object
        // parent empty to hand / make object move with hand

    }

    private void Raycast()
    {
        Vector3 origin = myOriginHolder.transform.position;
        Vector3 direction = myOriginHolder.transform.forward;
        //Vector3 direction =  myOriginHolder.transform.right;

        // Debug.Log(myOriginHolder.transform.position);

        Debug.DrawRay(origin, direction * maxDistance, Color.red);

        Ray ray = new Ray(origin, direction);

        // RaycastHit hitInfo;

        if (Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance, layerMask))
        {

            raycastHit.collider.GetComponent<Renderer>().material.color = Color.green;

            //makeConnection();

            //raycastHit.collider.GetComponent<Rigidbody>().mass = 1;
            //raycastHit.collider.GetComponent<Rigidbody>().useGravity = false;
            //raycastHit.collider.GetComponent<Rigidbody>().isKinematic = true;
            //raycastHit.collider.gameObject.AddComponent<FixedJoint>();
            //raycastHit.collider.GetComponent<FixedJoint>().connectedBody = GameObject.Find("Bone").GetComponent<Rigidbody>();

            // myOriginHolder.gameObject.AddComponent<FixedJoint>();
            // myOriginHolder.GetComponent<FixedJoint>().connectedBody = raycastHit.collider.GetComponent<Rigidbody>();

            //raycastHit.collider.GetComponent<Collider>().GetComponent<Renderer>().material.color = Color.green;

            greatGrandChildGrabbyHand = this.gameObject.transform.GetChild(2).GetChild(2).GetChild(0).gameObject;// change this if code in hand

            Vector3 pointOfConnection = new Vector3(greatGrandChildGrabbyHand.transform.position.x - raycastHit.collider.GetComponent<Collider>().gameObject.transform.position.x,
                                                    greatGrandChildGrabbyHand.transform.position.y - raycastHit.collider.GetComponent<Collider>().gameObject.transform.position.y,
                                                    greatGrandChildGrabbyHand.transform.position.z - raycastHit.collider.GetComponent<Collider>().gameObject.transform.position.z);

            emptyJointHolder = new GameObject("jointBuddy");
            emptyJointHolder.transform.position = pointOfConnection;
            emptyJointHolder.AddComponent<Rigidbody>();
            emptyJointHolder.AddComponent<FixedJoint>();

            emptyJointHolder.GetComponent<FixedJoint>().connectedBody = raycastHit.collider.GetComponent<Collider>().GetComponent<Rigidbody>();

            //emptyJointHolder.GetComponent<Transform>().SetParent(greatGrandChildGrabbyHand.gameObject);
            //player.transform.parent = newParent.transform;
            emptyJointHolder.transform.parent = greatGrandChildGrabbyHand.transform;

            raycastHit.collider.GetComponent<Collider>().GetComponent<Rigidbody>().mass = 1;
            raycastHit.collider.GetComponent<Collider>().GetComponent<Rigidbody>().useGravity = false;
            raycastHit.collider.GetComponent<Collider>().GetComponent<Rigidbody>().isKinematic = true;

            //box = raycastHit.collider.gameObject;
            //box.AddComponent<newJoystickControl>();//.enabled;// = (true);
            //box.GetComponent<newJoystickControl>().connectedBody

            //hitInfo.collider.gameObject.AddComponent<FixedJoint>();

            //myOriginHolder.gameObject.AddComponent<FixedJoint>();
            // myOriginHolder.GetComponent<FixedJoint>().connectedBody = raycastHit.collider.GetComponent<Rigidbody>();

            // makeConnection();

        }

        // bool result = Physics.Raycast(ray, out hitInfo, maxDistance);

        // if (result)
        // {
        //     hitInfo.collider.gameObject.AddComponent<FixedJoint>();
        // }
    }

    void Update()
    {

        Raycast();
    }

}
