using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{
    private Animator anim;
    public Transform powerHandle = null;
    public bool isTeleporting = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void OnAnimatorIK()
    {
        if (isTeleporting)
        {
            // Look at powerHandle
            anim.SetLookAtWeight(1);
            anim.SetLookAtPosition(powerHandle.position);

            // Move right hand toward powerHandle
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand,1);  
            anim.SetIKPosition(AvatarIKGoal.RightHand,powerHandle.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand,powerHandle.rotation);
        } else {
            // Reset lookAt and right hand position
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand,0);
            anim.SetLookAtWeight(0);
        }
    }
}
