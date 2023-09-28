using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float forwardMove = Input.GetAxis("Vertical");
        float sideMove = Input.GetAxis("Horizontal");

        if (forwardMove != 0)
        {
            rb.velocity = Vector3.forward * forwardMove * 5f;
        }
        if (sideMove != 0)
        {
            transform.Rotate(Vector3.up * sideMove * 5f);
        }
    }
}
