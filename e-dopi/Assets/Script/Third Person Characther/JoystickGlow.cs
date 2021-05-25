using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickGlow : MonoBehaviour
{

    public GameObject glowArrowUp;
    public GameObject glowArrowDown;
    public GameObject glowArrowRight;
    public GameObject glowArrowLeft;

    private VariableJoystick variableJoystick;

    private void Start()
    {
        variableJoystick = GetComponent<VariableJoystick>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(0, 0, variableJoystick.Vertical) + new Vector3(variableJoystick.Horizontal, 0, 0);

        if (direction.z > 0)
        {
            glowArrowUp.SetActive(true);
        }
        else
        {
            glowArrowUp.SetActive(false);
        }

        if (direction.z < 0)
        {
            glowArrowDown.SetActive(true);
        }
        else
        {
            glowArrowDown.SetActive(false);
        }

        if (direction.x > 0)
        {
            glowArrowRight.SetActive(true);
        }
        else
        {
            glowArrowRight.SetActive(false);
        }

        if (direction.x < 0)
        {
            glowArrowLeft.SetActive(true);
        }
        else
        {
            glowArrowLeft.SetActive(false);
        }
    }

}
