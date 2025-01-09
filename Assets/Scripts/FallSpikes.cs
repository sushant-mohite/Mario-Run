using System.Collections;
using UnityEngine;

public class FallSpikes : MonoBehaviour
{
    public GameObject spike1;
    public GameObject spike2;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
            StartCoroutine(EnableSpikes());
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            spike1.SetActive(false);
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            spike2.SetActive(false);
        }

    }

    IEnumerator EnableSpikes()
    {
        spike1.SetActive(true);
        yield return new WaitForSeconds(2f);

        spike2.SetActive(true);
    }

}
