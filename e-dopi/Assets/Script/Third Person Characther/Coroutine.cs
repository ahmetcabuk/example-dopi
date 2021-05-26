using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    public bool dissapear;
    public float disapearTime;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(nameof(Dissapear));
        }
    }

    IEnumerator Dissapear()
    {
        yield return null;
        //yield return new WaitForSeconds(disapear); 
        //yield return new WaitForEndOfFrame();
        //yield return new WaitUntil(() => dissapear == true);

        gameObject.SetActive(false);
    }

}
