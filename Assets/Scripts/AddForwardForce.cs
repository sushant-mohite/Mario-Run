using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForwardForce : MonoBehaviour
{
    public float zRotationForce = 100f;
    
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
      rb.AddForce(0, 0, zRotationForce * Time.deltaTime);
    }
}
