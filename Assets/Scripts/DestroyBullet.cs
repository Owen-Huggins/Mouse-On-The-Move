using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3);
    }

    public void BulletConnect()
    {
        Destroy(this.gameObject);
    }
}
