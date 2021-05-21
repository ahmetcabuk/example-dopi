using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public FinishCheck fC;

    public float speed = 5;

    private Rigidbody rB;
    private Vector3 m_EulerAngleVelocity;

    public bool startTime = false;
    public float time = 0;
    private bool finished;

    private Vector3 startPosition;
    private Vector3 startRotation;

    private void Start()
    {
        startPosition = gameObject.transform.position;
        startRotation = gameObject.transform.rotation.eulerAngles;

        rB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        finished = fC.finished;

        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);

        if (startTime && !finished)
        {
            time += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rB.AddRelativeForce(0f,0f,speed);
            startTime = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rB.AddRelativeForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_EulerAngleVelocity = new Vector3(0, 10, 0);
            rB.MoveRotation(rB.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_EulerAngleVelocity = new Vector3(0, -10, 0);
            rB.MoveRotation(rB.rotation * deltaRotation);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        rB.isKinematic = true;
        rB.isKinematic = false;
        gameObject.transform.position = startPosition;
        gameObject.transform.rotation = Quaternion.Euler(startRotation);

        startTime = false;
        time = 0;
    }
}
