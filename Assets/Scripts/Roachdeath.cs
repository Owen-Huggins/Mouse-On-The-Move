using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using MaskTransitions;

public class Roachdeath : MonoBehaviour
{
    public void DeathFromRoach()
    {
        //SceneManager.LoadScene("DeathScreen");
        //Time.timeScale = 1f;
        this.GetComponent<LifeTracker>().loseALife();
    }
}
