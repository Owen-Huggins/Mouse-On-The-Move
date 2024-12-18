using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Cockroach : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    private Animator anim;	
    public GameObject[] waypoints;
    private int currWaypoint; 

   


   void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        anim = GetComponent<Animator>();

        currWaypoint = 0;

        setNextWaypoint();
        

            
        
        
    }

    private void setNextWaypoint()
    {

        if (waypoints.Length == 0)
        {
            Debug.LogError("Waypoints is empty.");
            return;
        }

        navMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
        
        currWaypoint = (currWaypoint + 1) % waypoints.Length;






    }


        
    

    

    void Update()
    {

         anim.SetFloat("vely", navMeshAgent.velocity.magnitude / navMeshAgent.speed);

         if ( navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            setNextWaypoint();
        }
        

        
    }
}
