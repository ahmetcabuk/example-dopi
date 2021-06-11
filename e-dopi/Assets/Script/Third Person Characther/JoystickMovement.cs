using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class JoystickMovement : Singleton<JoystickMovement>
{
    public float maxSpeed;
    public VariableJoystick variableJoystick;
    [HideInInspector] public bool moveDeceleration = true;
    [HideInInspector] public bool moveLock = false;
    public Vector3 direction;

    private Rigidbody _rigid;
    private float _currentSpeed;
    private float _initialSpeed;
    private bool _speedIncreased = false;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _currentSpeed = maxSpeed / 2;
        _initialSpeed = maxSpeed;
    }
    private void Update()
    {
        CheckMoveDecelerationStatus();
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
            _rigid.MovePosition(transform.position + (direction * _currentSpeed * Time.deltaTime));
        }
        else
        {
            _rigid.MovePosition(transform.position + (direction * _currentSpeed * Time.deltaTime));
            if (!_speedIncreased)
            {
                SpeedIncrase();
            }
        }
    }

    private void CheckMoveDecelerationStatus()
    {
        if (direction == Vector3.zero)
        {
            moveDeceleration = true;
            _currentSpeed = maxSpeed / 2;
            _speedIncreased = false;
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
        _speedIncreased = true;
        DOTween.To(() => _currentSpeed, x => _currentSpeed = x, _initialSpeed, 1);
    }

    public void RestartInput()
    {
        variableJoystick.input = Vector2.zero;
        variableJoystick.handle.anchoredPosition = Vector3.zero;
    }
}


