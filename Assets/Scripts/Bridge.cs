using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMovement : MonoBehaviour
{
    private Vector3 previousPosition;
    private bool playerOnBridge = false;
    private CharacterController playerController;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        if (playerOnBridge && playerController != null)
        {
            // Calculate the bridge's movement delta
            Vector3 bridgeDelta = transform.position - previousPosition;

            // Move the player by the same delta
            playerController.Move(bridgeDelta);
        }

        // Update the previous position for the next frame
        previousPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnBridge = true;
            playerController = other.GetComponent<CharacterController>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnBridge = false;
            playerController = null;
        }
    }
}
