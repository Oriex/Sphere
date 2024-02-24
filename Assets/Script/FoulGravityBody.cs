using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoulGravityBody : MonoBehaviour
{
    public FoulGravity attractor;
    private Transform myTransform;

    private void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
    }

    private void Update()
    {
        attractor.Attract(myTransform);
    }
}
