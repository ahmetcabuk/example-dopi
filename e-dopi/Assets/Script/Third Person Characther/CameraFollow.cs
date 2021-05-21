using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject objectToFollow;
    public Vector3 positionMargin;

    void Start()
    {
        positionMargin = objectToFollow.transform.position - gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = objectToFollow.transform.position - positionMargin;
    }
}
