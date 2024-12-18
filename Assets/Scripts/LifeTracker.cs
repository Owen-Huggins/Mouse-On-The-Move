namespace MaskTransitions
{using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeTracker : MonoBehaviour
{
    private int numLives;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    private Vector3 startingPos;
    private Quaternion startingRot;
    private float lastHit;
    private bool immune;

    private Scene currentScene;
    private string sceneName;
    public AudioSource audio;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        immune = false;
        numLives = 3;
        startingPos = transform.position;
        startingRot = transform.GetChild(0).transform.rotation;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        anim = GetComponent<Animator>();
        anim.SetBool("dead", false);
    }

    void Update()
    {
        if (Time.time - lastHit >= 3f)
        {
            immune = false; // 3 seconds of invincibility
            anim.ResetTrigger("Hit");
        }
    }
    public void loseALife()
    {

        if (!immune)
        {
            anim.SetTrigger("Hit");
            audio.Play(0);
            numLives--;
            if (numLives == 2) Destroy(heart3);
            if (numLives == 1) Destroy(heart2);
            lastHit = Time.time;
            immune = true;

            if (numLives == 0) allLivesLost();           
        }
    }

    // Only restart if all lives lost or floor death
    public void floorDeath()
    {
        audio.Play(0);
        numLives--;
        if (numLives == 2) Destroy(heart3);
        if (numLives == 1) Destroy(heart2);
        lastHit = Time.time;
        immune = true;

        this.transform.position = startingPos;
        this.transform.GetChild(0).transform.rotation = startingRot;

        if (numLives == 0) allLivesLost();
    }

    private void allLivesLost()
    {
        Destroy(heart1);

        if (numLives == 0 && sceneName == "Boss Stage")
        {
            TransitionManager.Instance.LoadLevel("DeathScreen 2");
            Time.timeScale = 1f;
        }
        if (numLives == 0 && sceneName == "Stage1")
        {
            TransitionManager.Instance.LoadLevel("DeathScreen 1");
            Time.timeScale = 1f;
        }
    }
}
}