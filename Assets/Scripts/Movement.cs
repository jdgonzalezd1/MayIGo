using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 3f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardMove = Input.GetAxis("Vertical");
        float sideMove = Input.GetAxis("Horizontal");
        if(forwardMove != 0)
        {
            rb.velocity = Vector3.forward * forwardMove * speed;
        }
        if(sideMove != 0)
        {
            rb.velocity = Vector3.right * sideMove * speed;
        }
        
        
    }
}
