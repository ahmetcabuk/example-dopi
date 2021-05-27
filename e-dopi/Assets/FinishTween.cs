using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishTween : Singleton<FinishTween>
{
    public float moveUpDuration;
    public float rotateDuration;
    
    public void StartFinishAnimation()
    {
        StartCoroutine(nameof(FinishAnimation));
    }
    private IEnumerator FinishAnimation()
    {
        var rigid = GetComponent<Rigidbody>();

        rigid.useGravity = false;
        transform.DOMoveY(2, moveUpDuration);
        transform.DOLocalRotate(new Vector3 (transform.localRotation.x, (transform.localRotation.y + 180) , transform.localRotation.z), rotateDuration, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Incremental);
        
        yield return new WaitForSeconds(moveUpDuration);

        DOTween.Kill(gameObject.transform);
        GameManager.Instance.RestartLevel();
    }
}
