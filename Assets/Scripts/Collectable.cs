using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            Collector bc = c.attachedRigidbody.gameObject.GetComponent<Collector>();
            if (bc != null)
            {
                Destroy(this.gameObject);
                bc.ReceiveBall();
            }
        }
    }
}
