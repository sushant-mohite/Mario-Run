using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private RespawnScript respawn;
    public GameObject checkpointCube;
    public Material newMaterial;
    
    void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("Ocean").GetComponent<RespawnScript>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            respawn.respawnPoint = this.gameObject;
            checkpointCube.GetComponent<MeshRenderer>().material = newMaterial;
        }
    }
}
