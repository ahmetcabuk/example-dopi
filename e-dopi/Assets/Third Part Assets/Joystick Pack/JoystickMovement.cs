using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        //Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        Vector3 direction = new Vector3 (0,0,variableJoystick.Vertical) + new Vector3 (variableJoystick.Horizontal, 0,0);

        transform.eulerAngles = new Vector3(0, Mathf.Atan2(direction.x, direction.z) * 180 / Mathf.PI, 0);
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void Update()     
    {

    }


}
