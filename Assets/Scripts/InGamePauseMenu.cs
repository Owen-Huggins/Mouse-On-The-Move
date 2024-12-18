using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class InGamePauseMenu: MonoBehaviour
{
    CanvasGroup canvasGroup;
    private bool isPaused = false; 
    
    void Awake()
    {
        try {
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false; 
            canvasGroup.blocksRaycasts = false;
        } catch {
            Debug.LogError("Component not found");
        }
    }

    void Update()
    {
        if (Input.GetKeyUp (KeyCode.Escape)) {
            if (isPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    void Pause() 
    {

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        Time.timeScale = 0f;
        isPaused = true; 
        
    }


    void Resume() 
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
        Time.timeScale = 1f;
        isPaused = false; 

    }
}
