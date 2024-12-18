using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseCollector : MonoBehaviour
{
    public int CheeseCollected;

    void Start()
    {
        CheeseCollected = 0;
    }

    public void Collect()
    {
        CheeseCollected += 1;
    }
}
