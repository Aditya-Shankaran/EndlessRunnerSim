using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScriptController : MonoBehaviour
{
    Animator animator;
    int isRunningHash;
    int isJumpingHash;
    int isSlidingHash;
    int runnerPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //Debug.Log(animator);

        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isSlidingHash = Animator.StringToHash("isSliding");
        runnerPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed=Input.GetKey(KeyCode.W);
        bool jumpPressed = Input.GetKey(KeyCode.Space);
        bool slidePressed = Input.GetKey(KeyCode.LeftControl);

        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool isSliding = animator.GetBool(isSlidingHash);


                // Press D to move right
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (runnerPosition < 2)
                    {
                //transform.position = new Vector3(transform.position.x + 4.0f, transform.position.y, transform.position.z);
                transform.Translate(4, 0, 0);
                // increment the player position
                runnerPosition++;
                    }
                }
                // press A to move left
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (runnerPosition > 0)
                    {
                        //transform.position = new Vector3(transform.position.x - 4.0f, transform.position.y, transform.position.z);
                        transform.Translate(-4, 0, 0);
                        // decrement the player position
                        runnerPosition--;
                    }
                }

                // If W is pressed
                if (forwardPressed && !isRunning && !isJumping)
                {
                    // set boolean to be true
                    animator.SetBool(isRunningHash, true);
                }
                else if (!forwardPressed && isRunning) // if not then set boolean false
                    animator.SetBool(isRunningHash, false);

                if (forwardPressed && isRunning && jumpPressed && !isJumping)
                    animator.SetBool(isJumpingHash, true);
                else if (forwardPressed && isRunning && !jumpPressed)
                    animator.SetBool(isJumpingHash, false);

                if (forwardPressed && isRunning && slidePressed && !isSliding)
                    animator.SetBool(isSlidingHash, true);
                else if (forwardPressed && isRunning && !slidePressed)
                   animator.SetBool(isSlidingHash, false);
            
        
    }
}
