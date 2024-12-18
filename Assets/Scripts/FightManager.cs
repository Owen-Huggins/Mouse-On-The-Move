using UnityEngine;

public class FightManager : MonoBehaviour
{
    public GameObject exit;
    private int spiderCount;

    void Start()
    {
        spiderCount = GameObject.FindGameObjectsWithTag("Spider").Length;
        LockExit();
    }

    public void SpiderDefeated()
    {
        spiderCount--;

        if (spiderCount <= 0)
        {
            UnlockExit();
        }
    }

    private void LockExit()
    {
        exit.GetComponent<Collider>().enabled = false;
    }

    private void UnlockExit()
    {
        exit.GetComponent<Collider>().enabled = true;
    }
}
