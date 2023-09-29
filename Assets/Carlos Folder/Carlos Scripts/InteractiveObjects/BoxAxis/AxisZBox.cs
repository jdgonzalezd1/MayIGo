using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisZBox : MonoBehaviour
{
    private InteractiveBox box;
    private void Start()
    {
        box = GetComponentInParent<InteractiveBox>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            box.boxRigidbody.constraints = RigidbodyConstraints.FreezeRotation |
                                           RigidbodyConstraints.FreezePositionX |
                                           RigidbodyConstraints.FreezePositionY;
        }
        else
        {
            box.boxRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        box.boxRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        box.DesactivarEmpuje();

    }
}
