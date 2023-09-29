using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRigidBody : MonoBehaviour
{
    public float pushPower = 2.0f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // Si el objeto no tiene rigidbody o es kinematico. No queremos empujarlo
        if (body == null || body.isKinematic)
        {
            return;
        }

        // No queremos empujar hacia abajo, si caemos encima de un objeto
        if (hit.moveDirection.y < -0.3f)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.velocity = pushDir * pushPower;
    }
    
}
