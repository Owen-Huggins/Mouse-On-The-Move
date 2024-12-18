using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger1 : MonoBehaviour
{
    public void LoadStage()
    {
        SceneManager.LoadScene("Boss Stage");
        Time.timeScale = 1f;
    }
    public void LoadInstructionStage1()
    {
        SceneManager.LoadScene("Boss Stage");
        Time.timeScale = 1f;
    }
}
