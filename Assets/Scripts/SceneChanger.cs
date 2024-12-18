namespace MaskTransitions
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class StartGame : MonoBehaviour
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
    }
}
