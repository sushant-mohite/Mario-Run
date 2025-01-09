using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    
    public GameObject player;
    public GameObject respawnPoint;
    private CharacterController characterController;



    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable CharacterController temporarily
            characterController.enabled = false;

            // Move player
            player.transform.position = respawnPoint.transform.position;
            player.transform.rotation = respawnPoint.transform.rotation;
            
            // Re-enable CharacterController
            characterController.enabled = true;
            
        }
    }
}

