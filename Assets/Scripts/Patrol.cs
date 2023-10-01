using System.Collections;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Patrol : MonoBehaviour
{
    private int destPoint = 0;
    private NavMeshAgent agent;

    [SerializeField] private float stopTime = 5f;

    public Transform[] points;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {        
        if (points.Length == 0) return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;        
    }

    IEnumerator StayInPosition()
    {
        agent.isStopped = true;
        agent.speed = 0f;
        yield return new WaitForSeconds(stopTime);
        agent.isStopped = false; 
        agent.speed = 3f;        
    }

    private void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (gameObject.CompareTag("Janitor"))
            {                
                StartCoroutine(StayInPosition());               
            }
            GotoNextPoint();

        }
    }

}
