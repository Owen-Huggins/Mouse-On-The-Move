using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using MaskTransitions;


public class MouseTrap : MonoBehaviour 
{
    [SerializeField] private Animator mouseTrapController; 
    public AudioSource audioSource;
    public AudioClip trapSound; 
    private bool isPlayerInside = false; 
    private void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null && c.CompareTag("Mouse"))
        {
            mouseTrapController.SetBool("CloseHatch", true);

           
            isPlayerInside = true; 
            StartCoroutine(WaitForTrapToClose());
            
             

        }
       
    }

     private void OnTriggerExit(Collider c)
    {
         if (c.attachedRigidbody != null && c.CompareTag("Mouse"))
         {
            mouseTrapController.SetBool("CloseHatch", false);
            isPlayerInside = false; 
         }
        
    }

    private IEnumerator WaitForTrapToClose()
    {
        while (!IsTrapClosed())
        {
            yield return null; 
        }
        yield return new WaitForSeconds(GetAnimationClipLength("Close Hatch"));
        audioSource.PlayOneShot(trapSound);
        
        if (isPlayerInside && mouseTrapController.GetBool("CloseHatch") == true)
        {
            KillPlayer();

        }
    }

    private bool IsTrapClosed()
    {
        AnimatorStateInfo stateInfo = mouseTrapController.GetCurrentAnimatorStateInfo(0); 
        return stateInfo.IsName("Close Hatch");

    }

    private float GetAnimationClipLength(string clipName)
    {
        AnimationClip[] clips = mouseTrapController.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == clipName)
            {
                return clip.length;
            }
        }
        return 0f;
    }

    private void KillPlayer()
    {
        
        GameObject.Find("player").GetComponent<LifeTracker>().loseALife();   
    }
    
}