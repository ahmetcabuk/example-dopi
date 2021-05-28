using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Finish : Singleton<Finish>
{
    private Material material;
    private float startAlpha;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    private void Start()
    {
        StartCoroutine(nameof(Fade));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Mission Accomplished");
            FinishTween.Instance.StartFinishAnimation();
        }
    }

    private IEnumerator Fade()
    {
        material.DOFade(0, 1).SetLoops(-1,LoopType.Yoyo);
        yield return null;
    }
}
