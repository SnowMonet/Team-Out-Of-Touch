using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingScript : MonoBehaviour
{
    public GameObject GrabbableObject;

    private ConstantForce ArmForce;

    public Rigidbody CharacterRightArm;

    private bool WantsToGrab = false;

    //public float ArmForce;

    void Start()
    {
        ArmForce = GetComponent<ConstantForce>();
        // Hand = GrabbableObject.gameObject.AddComponent<FixedJoint>();
        //Hand
    }

    public void Grab()
    {
        ArmForce.enabled = !ArmForce.enabled;
        WantsToGrab = !WantsToGrab;
    }

    void OnTriggerEnter(Collider other)
    {
        if(WantsToGrab == true)
        {

        }
    }
}
