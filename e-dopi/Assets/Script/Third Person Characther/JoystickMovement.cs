using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rigid;

    public bool moveLock = false;

    public void FixedUpdate()
    {
        Vector3 direction = new Vector3 (0,0,variableJoystick.Vertical) + new Vector3 (variableJoystick.Horizontal, 0,0);

        rigid.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}


