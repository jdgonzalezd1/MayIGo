using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem boxParticle;
    public Rigidbody boxRigidbody;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        boxRigidbody = GetComponent<Rigidbody>();
    }

    public void ActivarEmpuje()
    {
        
        player.GetComponent<BasicRigidBodyPush>().canPush = true;

    }

    public void DesactivarEmpuje()
    {
        player.GetComponent<BasicRigidBodyPush>().canPush = false;

    }

}
