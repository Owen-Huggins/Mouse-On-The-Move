namespace MaskTransitions
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class CheeseCollectible : MonoBehaviour
    {

        public AudioSource audioSource;
        public AudioClip collect;
        public GameObject player;

        // Start is called before the first frame update

        void OnTriggerEnter(Collider c)
        {
            if (c.CompareTag("Player"))
            {
                if (audioSource != null && collect != null)
                {
                    audioSource.PlayOneShot(collect);
                }
                Destroy(this.gameObject);
                TransitionManager.Instance.LoadLevel("TransitionToBoss");
                Time.timeScale = 1f;
            }
        }
    }
}