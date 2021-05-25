using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenPatrol : MonoBehaviour
{
    public Vector3 destinationPos;
    public float duration;
    public Ease ease;
   



    void Start()
    {
        transform.DOMove(destinationPos,duration).SetLoops(-1,LoopType.Yoyo).SetEase(ease);
    }
}
