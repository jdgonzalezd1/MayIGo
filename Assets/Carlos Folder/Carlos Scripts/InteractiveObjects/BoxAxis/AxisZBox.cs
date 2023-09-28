using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisZBox : MonoBehaviour
{
    private InteractiveBox box;
    RigidbodyConstraints rigidbodyConstraints;
    private void Start()
    {
        box = GetComponentInParent<InteractiveBox>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rigidbodyConstraints = box.boxRigidbody.constraints;
            box.boxRigidbody.constraints = RigidbodyConstraints.FreezeRotation |
                                           RigidbodyConstraints.FreezePositionX |
                                           RigidbodyConstraints.FreezePositionY;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        box.boxRigidbody.constraints = rigidbodyConstraints;
        box.DesactivarEmpuje();

    }
}
