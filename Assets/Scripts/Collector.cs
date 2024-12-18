using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int hasBall = 25;

    public void ReceiveBall()
    {
        hasBall += 1;
    }
    public void ThrowBall()
    {
        hasBall -= 1;
    }
}
