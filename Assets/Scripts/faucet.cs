using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faucet : MonoBehaviour
{

    private Rigidbody rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
