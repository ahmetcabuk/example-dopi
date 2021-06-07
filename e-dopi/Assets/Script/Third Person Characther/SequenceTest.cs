using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceTest : MonoBehaviour
{
    public List<GameObject> cameraSequenceList;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CameraZoom.Instance.ZoomSequenceCoroutine(cameraSequenceList));
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        UIController.Instance.CoroutineExecuter("HideUIElement", UIController.Instance.interactionButton);
    //    }
    //}
}
