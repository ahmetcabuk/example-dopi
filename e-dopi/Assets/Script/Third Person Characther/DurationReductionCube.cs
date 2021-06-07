using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DurationReductionCube : MonoBehaviour
{
    public bool dissapear = false;
    public float disapearTime;

    public UnityEvent onDissapearChanged;

    public bool Dissapear
    {
        get => dissapear;

        set
        {
            onDissapearChanged.Invoke();
            dissapear = value;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance.success);
            StartCoroutine(nameof(DissapearCoroutine));
        }
    }

    IEnumerator DissapearCoroutine()
    {
        yield return null;
        
        Dissapear = true;
        gameObject.SetActive(false);
    }
}
