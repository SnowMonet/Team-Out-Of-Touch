using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float CharacterMF;               //CF = movement force
    public Rigidbody CharacterRB;                 //RB=Rigidbody

    void Start()
    {
        CharacterRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey("w"))
        {
            CharacterRB.AddForce(Vector3.forward * CharacterMF);
        }

        if (Input.GetKey("s"))
        {
            CharacterRB.AddForce(Vector3.back * CharacterMF);
        }

        if (Input.GetKey("a"))
        {
            CharacterRB.AddForce(Vector3.left * CharacterMF);
        }

        if (Input.GetKey("d"))
        {
            CharacterRB.AddForce(Vector3.right * CharacterMF);
        }
    }
}
