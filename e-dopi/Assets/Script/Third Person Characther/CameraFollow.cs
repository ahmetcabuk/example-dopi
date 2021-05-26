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
    private bool lookAt;
    [SerializeField]
    [Range(0, 1)]
    private float _smoothSpeed = 0.125f;
    


    void Start()
    {
        _targetPositionOffset = target.transform.position + gameObject.transform.position;

        //if (!_smoothness)
        //{
        //    _smoothSpeed = 1;
        //}
    }

    private void FixedUpdate()
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
