using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObject : MonoBehaviour
{
    public GameObject ObjectToSnap;
    public Transform ObjectPos;

    private bool InPlace = false;

    private Rigidbody TankRigidBody;

    private void Start()
    {
        TankRigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tank")
        {
            ObjectToSnap.transform.position = ObjectPos.transform.position;
            ObjectToSnap.transform.rotation = ObjectPos.transform.rotation;
            InPlace = true;
        }
    }

    private void FixedUpdate()
    {
        if (InPlace == true)
        {
            TankRigidBody.velocity = Vector3.zero;
            TankRigidBody.angularVelocity = Vector3.zero;
        }
    }
}
