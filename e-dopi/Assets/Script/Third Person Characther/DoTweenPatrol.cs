using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenPatrol : MonoBehaviour
{
    public Material whiteMaterial;

    public GameObject durationMultiplyCube;
    public Vector3 destinationPos;
    public float duration;
    public float durationMultiply;

    private Vector3 startPosition;
    private Coroutine coroutine;

    public bool dissapear;

    void Awake()
    {
        startPosition = gameObject.transform.position;
        transform.DOMove(destinationPos,duration).SetLoops(-1,LoopType.Yoyo);
        StartCoroutine(nameof(MultiplyDuration));
        coroutine = durationMultiplyCube.GetComponent<Coroutine>();
    }

    private void Update()
    {
        dissapear = coroutine.dissapear;
    }

    IEnumerator MultiplyDuration()
    {
        yield return new WaitUntil(() => dissapear == true);
        gameObject.GetComponent<Renderer>().material = whiteMaterial;
        DOTween.Kill(gameObject.transform);
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove(startPosition, (duration * durationMultiply)));
        seq.Append(transform.DOMove(destinationPos, (duration * durationMultiply)).SetLoops(10000, LoopType.Yoyo));
    }
}
