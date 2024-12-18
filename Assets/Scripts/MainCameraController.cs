using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainCameraController : MonoBehaviour
{
    // Camera distance from player
    public Vector3 offset = new Vector3(0f, 0.3f, -.5f); 

    public float smoothing = .125f;
    public GameObject player;
    public float m_position;
 

    // Update is called once per frame
    void Update()
    {
        // Rotate Camera: Q and E
        Vector3 lookAtPosition = player.transform.GetChild(0).position + player.transform.GetChild(0).rotation * offset; // Set to mouse object

        transform.position = Vector3.Lerp(transform.position, lookAtPosition, smoothing);
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.GetChild(0).rotation, smoothing);

    }
}
