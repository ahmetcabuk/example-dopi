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
            StartCoroutine(nameof(DissapearCoroutine));
        }
    }

    IEnumerator DissapearCoroutine()
    {
        yield return null;
        //yield return new WaitForSeconds(disapear); 
        //yield return new WaitForEndOfFrame();
        //yield return new WaitUntil(() => dissapear == true);

        
        Dissapear = true;
        gameObject.SetActive(false);
    }

}
