using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CorrectDirection : MonoBehaviour
{
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.forward = rb.velocity.normalized;
        //transform.rotation = Quaternion.LookRotation(rb.velocity.normalized);
    }
}
