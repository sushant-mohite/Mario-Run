using System.Collections;
using UnityEngine;

public class RollerInstantiation : MonoBehaviour
{
    public GameObject rollerPrefab;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            Vector3 spawnPosition1 = new Vector3(-8.5f, 5.4f, -41.75f);
            Vector3 spawnPosition2 = new Vector3(-10.15f, 8f, -42.75f);

            Quaternion spawnRotation = Quaternion.Euler(0, 90, 0);

            Instantiate(rollerPrefab, spawnPosition1, spawnRotation, transform.parent);

            StartCoroutine(SpawnScondRoller(spawnPosition2, spawnRotation));
        }
    }

    IEnumerator SpawnScondRoller(Vector3 spawnPosition2, Quaternion spawnRotation)
    {
        yield return new WaitForSeconds(1f);
        Instantiate(rollerPrefab, spawnPosition2, spawnRotation, transform.parent);

    }

}