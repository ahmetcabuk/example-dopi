using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    [Range(0.1f, 0.9f)]
    public float runLimit;

    private Animator animator;
    private bool running = false;
    private JoystickMovement joystickMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        joystickMovement = GetComponent<JoystickMovement>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        var moveLock = joystickMovement.moveLock;

        if (direction != new Vector3(0,0,0))
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(direction.x, direction.z) * 180 / Mathf.PI, 0);

            animator.SetBool("isWalking", true);

            if (!AudioManager.Instance.audioSource.isPlaying && running == false)
            {
                var randomPitch = Random.Range(1f, 1.2f);
                
                AudioManager.Instance.PlaySFX3D(AudioKeys.FootStepLong, gameObject.transform.position, .5f, randomPitch);
            }

            if (direction.x > runLimit && !moveLock || direction.x < -runLimit && !moveLock ||  direction.z > runLimit && !moveLock || direction.z < -runLimit && !moveLock)
            {
                running = true;
                animator.SetBool("isRunning", true);

                if (!AudioManager.Instance.audioSource.isPlaying && running == true)
                {
                    var randomPitch = Random.Range(0.8f, 1f);

                    AudioManager.Instance.PlaySFX3D(AudioKeys.FootStepShort, gameObject.transform.position, .5f, randomPitch);
                }
            }
            else
            {
                running = false;
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
