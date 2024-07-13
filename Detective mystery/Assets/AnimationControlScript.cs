using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlScript : MonoBehaviour
{
    public bool isDead = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");
        bool talking = animator.GetBool("talk");
        bool isShooting = animator.GetBool("isShooting");
        bool ForwardPressed = Input.GetKey("w");
        bool RightwardPressed = Input.GetKey("d");
        bool LeftwardPressed = Input.GetKey("a");
        bool BackwardPressed = Input.GetKey("s");
        bool RunPressed = Input.GetKey("space");
        bool speakEnabled = Input.GetKey("f");
        bool Shoot = Input.GetButton("Fire1");

        if(!isWalking && (ForwardPressed || RightwardPressed|| LeftwardPressed|| BackwardPressed)){
            animator.SetBool("isWalking", true);
        }
        if(isWalking && !(ForwardPressed || RightwardPressed|| LeftwardPressed|| BackwardPressed)){
            animator.SetBool("isWalking", false);
        }

        if(!isRunning && RunPressed && (ForwardPressed || RightwardPressed|| LeftwardPressed|| BackwardPressed)){
            animator.SetBool("isRunning", true);
        }
        if(isRunning && (!RunPressed || (!ForwardPressed && !RightwardPressed &&!LeftwardPressed && !BackwardPressed))){
            animator.SetBool("isRunning", false);
        }

        if(!talking && speakEnabled){
            animator.SetBool("talk", true);
        }
        if(talking &&(!speakEnabled)){
            animator.SetBool("talk", false);
        }

        if(Shoot && !isShooting){
            animator.SetBool("isShooting", true);
        }
        if(!Shoot && isShooting){
            animator.SetBool("isShooting", false);
        }
        if(isDead){
            animator.SetBool("isDead", true);
        }

    }

}
