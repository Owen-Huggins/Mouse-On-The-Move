using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class Floordeath : MonoBehaviour
{
    public void Death()
    {
        SceneManager.LoadScene("DeathScreen");
        Time.timeScale = 1f;
    }
}
