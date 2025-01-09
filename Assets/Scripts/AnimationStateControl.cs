using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateControl : MonoBehaviour
{
    Animator animator;
    int IsWalkingHash;
    int IsRunningHash;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("IsWalking");
        IsRunningHash = Animator.StringToHash("IsRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool IsWalking = animator.GetBool(IsWalkingHash);
        bool IsRunning = animator.GetBool(IsRunningHash);
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        
        if (!IsWalking && forwardPressed)
        {
            animator.SetBool(IsWalkingHash, true);
        }

        if (IsWalking && !forwardPressed)
        {
            animator.SetBool(IsWalkingHash, false);
        }

        
        
        if (!IsRunning && forwardPressed && runPressed)
        {
            animator.SetBool(IsRunningHash, true);
        }

        if (IsRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(IsRunningHash, false);
        }
    }
}
