using UnityEngine;

public class Cobweb : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 0.5f;
    private float originalSpeed = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mouse"))
        {
            PlayerController playerController = other.transform.parent.GetComponent<PlayerController>();
            if (playerController != null)
            {
                originalSpeed = playerController.speed;
                playerController.speed *= speedMultiplier;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mouse"))
        {
            PlayerController playerController = other.transform.parent.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.speed = originalSpeed;
            }
        }
    }
}
