namespace MaskTransitions  
 {   
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneChanger : MonoBehaviour
    {
        public void LoadStage1()
        {
            TransitionManager.Instance.LoadLevel("Stage1");
            Time.timeScale = 1f;
        }

        public void LoadMain()
        {
            TransitionManager.Instance.LoadLevel("MainMenu");
            Time.timeScale = 1f;
        }
        public void LoadBoss()
        {
            TransitionManager.Instance.LoadLevel("Boss Stage");
            Time.timeScale = 1f;
        }
    }}

