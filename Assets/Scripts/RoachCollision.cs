using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskTransitions;

public class RoachCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            LifeTracker rd = c.attachedRigidbody.gameObject.GetComponent<LifeTracker>();
            if (rd != null)
            {
                rd.loseALife();
            }
            DestroyBullet rc = c.attachedRigidbody.gameObject.GetComponent<DestroyBullet>();
            if (rc != null)
            {
                Destroy(this.gameObject);
                rc.BulletConnect();
            }
        }
    }
}
