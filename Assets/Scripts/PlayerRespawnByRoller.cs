using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnByRoller : MonoBehaviour
{
    private GameObject player;
    private GameObject checkpoint1;
    private CharacterController controller;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        checkpoint1 = GameObject.FindGameObjectWithTag("Checkpoint1");
        controller = player.GetComponent<CharacterController>();

    }
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            controller.enabled = false;

            player.transform.position = checkpoint1.transform.position; 

            controller.enabled = true;
        }


    }
}
