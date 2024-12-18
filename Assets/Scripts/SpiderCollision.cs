using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaskTransitions;

public class SpiderCollision : MonoBehaviour
{
    private FightManager fightManager;

    void Start()
    {
        fightManager = FindObjectOfType<FightManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            LifeTracker lifeTracker = other.attachedRigidbody.gameObject.GetComponent<LifeTracker>();
            if (lifeTracker != null)
            {
                lifeTracker.loseALife();
            }
            DestroyBullet destroyBullet = other.attachedRigidbody.gameObject.GetComponent<DestroyBullet>();
            if (destroyBullet != null)
            {
                Destroy(this.gameObject);
                destroyBullet.BulletConnect();

                if (fightManager != null)
                {
                    fightManager.SpiderDefeated();
                }
            }
        }
    }
}
