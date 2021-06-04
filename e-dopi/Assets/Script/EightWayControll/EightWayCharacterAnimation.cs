using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightWayCharacterAnimation : MonoBehaviour
{
    private Animator animator;
    private EightWayControll eightWayControll;
    public bool isMoving;
    private void Start()
    {
        animator = GetComponent<Animator>();
        eightWayControll = GetComponent<EightWayControll>();
    }

    private void FixedUpdate()
    {
        if (eightWayControll.direction != new Vector3(0,0,0))
        {
            animator.SetBool("isRunning", true);
        }

        else
        {
            animator.SetBool("isRunning", false);
        }


        //if (isMoving)
        //{
        //    animator.SetBool("isRunning", true);
        //}
        //else
        //{
        //    animator.SetBool("isRunning", false);
        //}


        //if (direction != new Vector3(0, 0, 0))
        //{
        //    transform.eulerAngles = new Vector3(0, Mathf.Atan2(direction.x, direction.z) * 180 / Mathf.PI, 0);

        //    animator.SetBool("isWalking", true);

        //    if (!AudioManager.Instance.audioSource.isPlaying && running == false)
        //    {
        //        var randomPitch = Random.Range(1f, 1.2f);

        //        AudioManager.Instance.PlayAudio(AudioManager.Instance.footStepLong, .5f, randomPitch);
        //    }

        //    if (direction.x > runLimit || direction.x < -runLimit || direction.z > runLimit || direction.z < -runLimit)
        //    {
        //        running = true;
        //        animator.SetBool("isRunning", true);

        //        if (!AudioManager.Instance.audioSource.isPlaying && running == true)
        //        {
        //            var randomPitch = Random.Range(0.8f, 1f);

        //            AudioManager.Instance.PlayAudio(AudioManager.Instance.footStepShort, .5f, randomPitch);
        //        }
        //    }
        //    else
        //    {
        //        running = false;
        //        animator.SetBool("isRunning", false);
        //    }
        //}
        //else
        //{
        //    animator.SetBool("isWalking", false);
        //    animator.SetBool("isRunning", false);
        //}
    }
}
