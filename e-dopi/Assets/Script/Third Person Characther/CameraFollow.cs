using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 _targetPositionOffset;
    
    [Header("Smooth Camera")]
    [SerializeField]
    private bool _smoothness;
    [SerializeField]
    [Range(0, 1)]
    private float _smoothSpeed;
    private CameraZoom _cameraZoom;
    private bool _zoomOn;

    private void Start()
    {
        //var player = GameObject.Find("Player");

        //for (int i = 0; i < 25; i++)
        //{
        //    target = GameObject.Find("Player");
        //}

        _cameraZoom = GetComponent<CameraZoom>();
        _targetPositionOffset = target.transform.position + gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        _zoomOn = _cameraZoom.zoomOn;

        if (!_zoomOn)
        {
            if (!_smoothness)
            {
                _smoothSpeed = 1;
            }

            Vector3 desiredPosition = target.transform.position + _targetPositionOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
