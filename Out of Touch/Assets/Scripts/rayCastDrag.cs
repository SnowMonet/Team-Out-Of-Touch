using UnityEngine;
using System.Collections;

public class rayCastDrag : MonoBehaviour
{
    public GameObject myOriginHolder;
    public GameObject greatGrandChildGrabbyHand;
    public GameObject emptyJointHolder;

    public float maxDistance = 5f;

    [SerializeField]
    private LayerMask layerMask;

    bool isCarrying = false;
    

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

        if (Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance, layerMask) && !isCarrying)
        {
           
            raycastHit.collider.GetComponent<Renderer>().material.color = Color.green;

            //makeConnection();

            raycastHit.collider.GetComponent<Rigidbody>().mass = 1;
            raycastHit.collider.GetComponent<Rigidbody>().useGravity = true;
            //raycastHit.collider.GetComponent<Rigidbody>().isKinematic = true;
            raycastHit.collider.gameObject.AddComponent<FixedJoint>();
            raycastHit.collider.GetComponent<FixedJoint>().connectedBody = GameObject.Find("Fingers.r.002").GetComponent<Rigidbody>();

            // myOriginHolder.gameObject.AddComponent<FixedJoint>();
            // myOriginHolder.GetComponent<FixedJoint>().connectedBody = raycastHit.collider.GetComponent<Rigidbody>();
            isCarrying = true;
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



