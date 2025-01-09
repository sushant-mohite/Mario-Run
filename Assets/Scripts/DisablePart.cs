using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePart : MonoBehaviour
{
    public GameObject gamePart;

    void OnTriggerEnter(Collider other)
    {
        gamePart.SetActive(false);
    }

}
