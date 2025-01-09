using UnityEngine;

public class EnablePart4B : MonoBehaviour
{
    public GameObject[] enableChakris;
    public GameObject[] enableHammers; 

    public GameObject[] disableCutterRotators;
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
            foreach (GameObject obj in enableHammers)
            {
                HammerRotate hammerRotate = obj.GetComponent<HammerRotate>();

                if(!hammerRotate.enabled)
                {
                    hammerRotate.enabled = true;
                }
            }

            foreach (GameObject obj in enableChakris)
            {
                CutterRotator cutterRotator = obj.GetComponent<CutterRotator>();
                Animator animator = obj.GetComponent<Animator>();

                if(!cutterRotator.enabled && !animator.enabled)
                {
                    cutterRotator.enabled = true;
                    animator.enabled = true;
                }
                
            }
            
            
            foreach (GameObject obj in disableCutterRotators)
            {
                Rotator rotator = obj.GetComponent<Rotator>();
                
                if (rotator.enabled)
                {
                    rotator.enabled = false;
                }
            }

            if(bridgeAnimator.enabled)
            {
                bridgeAnimator.enabled = false;
            }
        }
    }
}