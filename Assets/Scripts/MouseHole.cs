using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHole : MonoBehaviour
{
    public Transform player, destination; 
    public GameObject playerG;

 
    void OnTriggerEnter(Collider other) 
    {

        if (other.CompareTag("Player")) 
        {

            player.position = destination.position; 


        }

    }

}
