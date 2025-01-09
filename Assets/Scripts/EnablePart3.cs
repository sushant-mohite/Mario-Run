using UnityEngine;

public class EnablePart3 : MonoBehaviour
{
    public GameObject[] rotators; 
    public GameObject bridge;
    Animator bridgeAnimator;

    void Start()
    {
        bridgeAnimator = bridge.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject obj in rotators)
            {
                Rotator rotator = obj.GetComponent<Rotator>();
                
                if (!rotator.enabled)
                {
                    rotator.enabled = true;
                }
            }
        }

        if(!bridgeAnimator.enabled)
        {
            bridgeAnimator.enabled = true;
        }
    }
}


