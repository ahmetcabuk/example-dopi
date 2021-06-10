using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickControl : Singleton<JoystickControl>
{
    public GameObject bG;
    public GameObject handle;
    private Image image;
    private Image bGImage;
    private Image handleImage;
    public bool lockJoystick = false;

    private void Awake()
    {
        image = GetComponent<Image>();
        bGImage = bG.GetComponent<Image>();
        handleImage = handle.GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lockJoystick = !lockJoystick;
        }

        if (lockJoystick)
        {
            image.raycastTarget = false;
            bGImage.raycastTarget = false;
            handleImage.raycastTarget = false;
        }
        else
        {
            image.raycastTarget = true;
            bGImage.raycastTarget = true;
            handleImage.raycastTarget = true;
        }
    }
}
