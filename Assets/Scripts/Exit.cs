
namespace MaskTransitions
{using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GetComponent<Collider>().enabled)
            {
                TransitionManager.Instance.LoadLevel("WinScreen");
                Time.timeScale = 1f;
            }
            else
            {
                Debug.Log("Exit is still locked. Defeat all spiders first!");
            }
        }
    }
}}
