using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class CameraZoom : Singleton<CameraZoom>
{
    public bool zoomOn = false;
    public GameObject targetSingleZoomObject;
    public string zoomObjectName;
    public GameObject fpsView;
    public float zoomAnimationDuration;

    private Camera _cam;
    private CameraFollow _cameraFollow;
    private Vector3 beforeZoomPosition;
    private Vector3 beforeZoomRotation;
    private GameObject _zoomObject;
    private bool animationFinish = false;

    private Sequence sequence;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
        _cameraFollow = GetComponent<CameraFollow>();
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
            transform.DORotate(beforeZoomRotation, zoomAnimationDuration);
        }
    }

    public void Zoom()
    {
        beforeZoomPosition = transform.position;
        beforeZoomRotation = transform.rotation.eulerAngles;

        if (!zoomOn)
        {
            _zoomObject = targetSingleZoomObject.transform.Find(zoomObjectName).gameObject;
            zoomOn = true;
            transform.DOMove(_zoomObject.transform.position, zoomAnimationDuration);
            transform.DORotate(_zoomObject.transform.rotation.eulerAngles, zoomAnimationDuration);
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomOut()
    {
        zoomOn = false;
        transform.DORotate(beforeZoomRotation, zoomAnimationDuration);
    }

    public IEnumerator ZoomSequenceCoroutine(List<GameObject>  sequenceTargetList)
    {
        beforeZoomPosition = transform.position;
        beforeZoomRotation = transform.rotation.eulerAngles;

        sequence = DOTween.Sequence();
        zoomOn = true;

        for (int i = 0; i < sequenceTargetList.Capacity; i++)
        {
            if (i == sequenceTargetList.Count - 1)
            {
                sequence.Append(transform.DOMove(sequenceTargetList[i].transform.position, zoomAnimationDuration));
                sequence.Join(transform.DORotate(sequenceTargetList[i].transform.rotation.eulerAngles, zoomAnimationDuration)).OnComplete(SequenceComplete);
            }
            else
            {
                sequence.Append(transform.DOMove(sequenceTargetList[i].transform.position, zoomAnimationDuration));
                sequence.Join(transform.DORotate(sequenceTargetList[i].transform.rotation.eulerAngles, zoomAnimationDuration));
            }
        }

        yield return new WaitUntil(() => animationFinish);
        ZoomOut();
    }

    public void SequenceComplete()
    {
        animationFinish = true;
    }
}
