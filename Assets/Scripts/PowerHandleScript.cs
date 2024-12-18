using UnityEngine;
using System.Collections;

public class PowerHandleScript : MonoBehaviour
{
    public Animator handleAnimator;
    public AudioSource handleSound;
    public string mouseTag = "Player";
    private bool isMouseNear = false;
    public Transform player, destination;
    public GameObject playerG;

    private void Update()
    {
        if (isMouseNear && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter key pressed - triggering animation and sound.");
            TriggerHandleInteraction();
            StartCoroutine(TransportPlayerWithDelay(1.4f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(mouseTag))
        {
            isMouseNear = true;
            Debug.Log("Mouse is near the power handle.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(mouseTag))
        {
            isMouseNear = false;
            Debug.Log("Mouse is no longer near the power handle.");
        }
    }

    private void TriggerHandleInteraction()
    {
        player.GetComponent<IKControl>().isTeleporting = true;
        handleAnimator.SetTrigger("PushDown");
        handleSound.Play();
        Debug.Log("Sound is played");
    }

    private IEnumerator TransportPlayerWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerG.SetActive(false);
        player.GetComponent<IKControl>().isTeleporting = false;
        player.position = destination.position;
        playerG.SetActive(true);
    }
}