using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMove : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 move = new Vector3(0, 0, 1) * speed;
            transform.Translate(move * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 move = new Vector3(0, 0, -1) * speed;
            transform.Translate(move * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 move = new Vector3(1, 0, 0) * speed;
            transform.Translate(move * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 move = new Vector3(-1, 0, 0) * speed;
            transform.Translate(move * speed * Time.deltaTime);
        }
    }
}
