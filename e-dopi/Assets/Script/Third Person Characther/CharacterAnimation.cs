using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    [Range(0.1f, 0.9f)]
    public float runLimit;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;

        if (direction != new Vector3(0,0,0))
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(direction.x, direction.z) * 180 / Mathf.PI, 0);

            animator.SetBool("isWalking", true);

            if (direction.x > runLimit || direction.x < -runLimit ||  direction.z > runLimit || direction.z < -runLimit)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
    }
}
