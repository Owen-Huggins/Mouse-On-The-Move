namespace MaskTransitions
{   using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneChangerNew : MonoBehaviour
    {
        public void LoadStage()
        {
            TransitionManager.Instance.LoadLevel("InstructionsStage1");
            Time.timeScale = 1f;
        }
        public void LoadInstructionStage1()
        {
            TransitionManager.Instance.LoadLevel("InstructionsStage1");
            Time.timeScale = 1f;
        }
        public void LoadStage1()
        {
            TransitionManager.Instance.LoadLevel("Stage1");
            Time.timeScale = 1f;
        }
        public void LoadBoss()
        {
            TransitionManager.Instance.LoadLevel("Boss Stage");
            Time.timeScale = 1f;
        }

        public void LoadMain()
        {
            TransitionManager.Instance.LoadLevel("MainMenu");
            Time.timeScale = 1f;
        }
    }
}