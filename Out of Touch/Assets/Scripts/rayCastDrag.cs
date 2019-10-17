using UnityEngine;
using System.Collections;

public class rayCastDrag : MonoBehaviour
{
    public GameObject myOriginHolder;

    [SerializeField]
    private LayerMask layerMask;
    public float maxDistance = 5f;

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
            raycastHit.collider.GetComponent<Rigidbody>().mass = 1;
            raycastHit.collider.GetComponent<Rigidbody>().useGravity = false;
            raycastHit.collider.GetComponent<Rigidbody>().isKinematic = true;
            //raycastHit.collider.gameObject.AddComponent<FixedJoint>();
            //raycastHit.collider.GetComponent<FixedJoint>().connectedBody = GameObject.Find("Bone").GetComponent<Rigidbody>();

            myOriginHolder.gameObject.AddComponent<FixedJoint>();
            myOriginHolder.GetComponent<FixedJoint>().connectedBody = raycastHit.collider.GetComponent<Rigidbody>();

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


/* private void FireGun()
{
    Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);

    muzzleParticle.Play();
    gunFireSource.Play();

    Ray ray = new Ray(firePoint.position, firePoint.forward);
    RaycastHit hitInfo;

    if (Physics.Raycast(ray, out hitInfo, 100))
    {
        var health = hitInfo.collider.GetComponent<Health>();

        if (health != null)
            health.TakeDamage(damage);
    }
}


/* public float distance = 1f;
 public LayerMask boxMask;

 GameObject box;
 // Use this for initialization
 void Start()
 {

 }

 // Update is called once per frame
 void Update()
 {

     //Physics.queriesStartInColliders = false;
     RaycastHit hit = Physics.Raycast(transform.position, Vector3.right * transform.localScale.x, distance, boxMask);

     if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKeyDown(KeyCode.E))
     {


         box = hit.collider.gameObject;
         box.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
         box.GetComponent<FixedJoint>().enabled = true;
         box.GetComponent<boxpull>().beingPushed = true;

     }
     else if (Input.GetKeyUp(KeyCode.E))
     {
         box.GetComponent<FixedJoint>().enabled = false;
         box.GetComponent<boxpull>().beingPushed = false;
     }

 }


 void OnDrawGizmos()
 {
     Gizmos.color = Color.yellow;

     Gizmos.DrawLine(transform.position, (Vector3)transform.position + Vector3.right * transform.localScale.x * distance);



 }*/

   /* using UnityEngine;
using System.Collections;

public class boxpull : MonoBehaviour
{

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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mode == 0)
        {
            if (beingPushed == false)
            {
                transform.position = new Vector3(xPos, transform.position.y);
            }
            else
                xPos = transform.position.x;
        }
        else if (mode == 1)
        {

            if (beingPushed == false)
            {


                GetComponent<Rigidbody2D>().mass = imovableMass;

            }
            else
            {
                GetComponent<Rigidbody2D>().mass = defaultMass;
                //	GetComponent<Rigidbody2D> ().isKinematic = false;
            }

        }
    }


}*/
//}
