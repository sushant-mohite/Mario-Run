using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePart4 : MonoBehaviour
{
    public GameObject[] enableChakris; 
    public GameObject[] disableUpdownprops;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
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

            foreach (GameObject obj in disableUpdownprops)
            {
                Animator animator = obj.GetComponent<Animator>();

                if(animator.enabled)
                {
                    animator.enabled = false;
                }
            }
        }
    }
}


