using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerRotate : MonoBehaviour
{
    [SerializeField] float zRotation = 1f;
    
    void Update()
    {
        transform.Rotate(0,0,zRotation * Time.deltaTime);
    }
}
