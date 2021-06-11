using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JoystickMovement : Singleton<JoystickMovement>
{
    public float maxSpeed;
    public VariableJoystick variableJoystick;
    public Rigidbody rigid;
    public bool moveDeceleration = true;
    public bool moveLock = false;
    [HideInInspector]
    public Vector3 direction;

    private float currentSpeed;
    private float initialSpeed;
    private bool speedIncreased = false;

    private void Start()
    {
        currentSpeed = maxSpeed / 2;
        initialSpeed = maxSpeed;
    }
    private void Update()
    {
        CheckMoveLockStatus();
    }

    public void FixedUpdate()
    {
        if (moveLock)
        {
            direction = Vector3.zero;
        }
        else
        {
            direction = new Vector3(0, 0, variableJoystick.Vertical) + new Vector3(variableJoystick.Horizontal, 0, 0);
        }

        if (moveDeceleration)
        {
            rigid.MovePosition(transform.position + (direction * currentSpeed * Time.deltaTime));
        }
        else
        {
            rigid.MovePosition(transform.position + (direction * currentSpeed * Time.deltaTime));
            if (!speedIncreased)
            {
                SpeedIncrase();
            }
        }
    }

    private void CheckMoveLockStatus()
    {
        if (direction == Vector3.zero)
        {
            moveDeceleration = true;
            currentSpeed = maxSpeed / 2;
            speedIncreased = false;
        }
        else
        {
            if (moveDeceleration)
            {
                StartCoroutine(nameof(UnlockMoveLock));
            }
        }
    }

    private IEnumerator UnlockMoveLock()
    {
        yield return new WaitForSeconds(1f);
        moveDeceleration = false;
    }

    public void SpeedIncrase()
    {
        speedIncreased = true;
        DOTween.To(() => currentSpeed, x => currentSpeed = x, initialSpeed, 1);
    }

    public void RestartInput()
    {
        variableJoystick.input = Vector2.zero;
        variableJoystick.handle.anchoredPosition = Vector3.zero;
    }
}


