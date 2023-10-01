using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




[RequireComponent(typeof(NavMeshAgent))]
public class Patrol : MonoBehaviour
{
    //Gets the animator to change the Janitor's animations
    public Animator myAnim;

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    [SerializeField] private float stopTime = 5f;

    private void Start()
    {
        //gets the children's animator
        myAnim = GetComponentInChildren<Animator>();

        agent = GetComponent<NavMeshAgent>();
        //agent.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        myAnim.Play("mixamo_com");
        if (points.Length == 0) return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
        Debug.Log("Next point succeded");
        

    }

    IEnumerator StayInPosition()
    {
        
        agent.isStopped = true;
        myAnim.Play("Look Around");
        agent.speed = 0f;
        yield return new WaitForSeconds(stopTime);
        agent.isStopped = false; 
        agent.speed = 3f;
        Debug.Log("I worked");
        


    }

    private void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (gameObject.CompareTag("Janitor"))
            {                
                StartCoroutine(StayInPosition());
                Debug.Log("I finish my patrol");

                
            }
            GotoNextPoint();

        }
    }

}
