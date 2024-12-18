using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    // Gets game obejct
    public GameObject projectile;
    // Creates launchVelocity (set in unity)
    public float launchVelocity = 700f;

    public AudioSource audioSource;
    public AudioClip fireSound;
    public Animator anim;
    private Collector bc;

    void Start()
    {
        bc = transform.parent.gameObject.GetComponent<Collector>();
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        anim.ResetTrigger("Throw");
        // if left click is clicked
        if (Input.GetButtonDown("Fire1") && bc.hasBall > 0)
        {
            anim.SetTrigger("Throw"); // trigger for throwing animation
            // creates porjectile (bullet prefab)
            GameObject ball = Instantiate(projectile, transform.position,
                                                      transform.rotation);
            // Adds force 
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                 (0, launchVelocity, 0));

            bc.ThrowBall();

            if (audioSource != null && fireSound != null)
            {
                audioSource.PlayOneShot(fireSound);
            }
        }
    }
}

