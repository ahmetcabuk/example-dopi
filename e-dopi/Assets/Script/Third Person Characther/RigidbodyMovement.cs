using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public bool addForceMovement;
    public bool velocityMovement;
    public bool movePositionMovement;

    public bool isMoving = false;

    public float speed;

    private Rigidbody rigid;
    private Vector3 move;
    private Animator animator;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (addForceMovement)
        {
            velocityMovement = false;
            movePositionMovement = false;
        }

        if (velocityMovement)
        {
            addForceMovement = false;
            movePositionMovement = false;
        }

        if (movePositionMovement)
        {
            addForceMovement = false;
            velocityMovement = false;
        }

        SetDirection();
    }

    private void FixedUpdate()
    {
        if (addForceMovement)
        {
            AddForceMovement(move);
        }

        if (velocityMovement)
        {
            VelocityMovement(move);
        }

        if (movePositionMovement)
        {
            MovePositionMovement(move);
        }
    }

    private void AddForceMovement(Vector3 direction)
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(move * (speed * 100) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(move * (speed * 100) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(move * (speed * 100) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(move * (speed * 100) * Time.deltaTime);
        }
    }

    private void VelocityMovement(Vector3 direction)
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.velocity = direction * (speed * 10);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigid.velocity = direction * (speed * 10);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = direction * (speed * 10);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = direction * (speed * 10);
        }
    }

    private void MovePositionMovement(Vector3 direction)
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.MovePosition(transform.position + (direction * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigid.MovePosition(transform.position + (direction * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigid.MovePosition(transform.position + (direction * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigid.MovePosition(transform.position + (direction * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void SetDirection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            move = new Vector3(0, 0, 1);
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            move = new Vector3(0, 0, -1);
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            move = new Vector3(1, 0, 0);
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            move = new Vector3(-1, 0, 0);
            animator.SetBool("isRunning", true);
        }
    }
}
