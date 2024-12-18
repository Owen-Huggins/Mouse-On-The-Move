using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using MaskTransitions;

public class Floor : MonoBehaviour
{
    private void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            LifeTracker fd = c.attachedRigidbody.gameObject.GetComponent<LifeTracker>();
            if (fd != null)
            {
                fd.floorDeath();
            }
        }
    }
}
