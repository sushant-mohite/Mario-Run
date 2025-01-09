using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePart5 : MonoBehaviour
{
    public GameObject[] traps;
    public GameObject[] chakris; 
    public GameObject[] hammers; 
    public GameObject[] rotators;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject obj in traps)
            {
                Animator animator = obj.GetComponent<Animator>();

                if(!animator.enabled)
                {
                    animator.enabled = true;
                }
            }

            foreach (GameObject obj in chakris)
            {
                CutterRotator cutterRotator = obj.GetComponent<CutterRotator>();
                Animator animator = obj.GetComponent<Animator>();

                if(cutterRotator.enabled && animator.enabled)
                {
                    cutterRotator.enabled = false;                    
                    animator.enabled = false;
                }
            }

            foreach (GameObject obj in hammers)
            {
                HammerRotate hammerRotate = obj.GetComponent<HammerRotate>();

                if(hammerRotate.enabled)
                {
                    hammerRotate.enabled = false;
                }
            }

            foreach (GameObject obj in rotators)
            {
                Rotator rotator = obj.GetComponent<Rotator>();

                if(rotator.enabled)
                {
                    rotator.enabled = false;
                }
            }
        }
    }
}


