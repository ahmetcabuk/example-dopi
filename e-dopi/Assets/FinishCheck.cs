using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheck : MonoBehaviour
{
    public CharController cC;

    public bool finished = false;



    private void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Car"))
        {
            //Debug.Log();
            finished = true;
        }
    }
}
