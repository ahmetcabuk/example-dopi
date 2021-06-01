using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraZoom : MonoBehaviour
{
    public bool zoomOn = false;
    public GameObject targetObject;
    public string zoomObjectName;
    public GameObject fpsView;
    public float zoomAnimationDuration;
    //public CameraZoomEnum cameraZoomDirection;

    private Camera _cam;
    private CameraFollow _cameraFollow;
    private Vector3 initialPosition;
    private Vector3 initialRotation;
    private GameObject _zoomObject;


    private void Awake()
    {
        _cam = GetComponent<Camera>();
        _cameraFollow = GetComponent<CameraFollow>();
    }

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && zoomOn == false)
        {
            zoomOn = true;
            transform.DOMove(fpsView.transform.position, zoomAnimationDuration);
            transform.DORotate(fpsView.transform.rotation.eulerAngles, zoomAnimationDuration);
        }

        else if (Input.GetKeyDown(KeyCode.F) && zoomOn == true)
        {
            zoomOn = false;
            transform.DORotate(initialRotation, zoomAnimationDuration);
        }
    }

    public void Zoom()
    {
        if (!zoomOn)
        {
            _zoomObject = targetObject.transform.Find(zoomObjectName).gameObject;
            zoomOn = true;
            transform.DOMove(_zoomObject.transform.position, zoomAnimationDuration);
            transform.DORotate(_zoomObject.transform.rotation.eulerAngles, zoomAnimationDuration);
        }

        else
        {
            zoomOn = false;
            transform.DORotate(initialRotation, zoomAnimationDuration);
        }
    }
}

public enum CameraZoomEnum
{
    DirectionUp = 1,
    DirectionDown = 2,
    DirectionRight = 3,
    DirectionLeft = 4
}
