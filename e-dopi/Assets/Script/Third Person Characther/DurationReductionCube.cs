using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationReductionCube : MonoBehaviour
{
    public bool dissapear = false;
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

        dissapear = true;
        gameObject.SetActive(false);
    }

}
