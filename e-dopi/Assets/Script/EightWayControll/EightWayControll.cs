using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightWayControll : MonoBehaviour
{
    public float speed;
    
    public Rigidbody rigid;
    public Vector3 direction;

    public bool up = false;
    public bool down = false;
    public bool right = false;
    public bool left = false;
    public bool upRight = false;
    public bool upLeft = false;
    public bool downRight = false;
    public bool downLeft = false;

    private Animator animator;
    private bool multiDirection = false;
    private float multiDirectionSpeed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        multiDirectionSpeed = speed / 2;
    }

    public void FixedUpdate()
    {
        direction = new Vector3(0, 0, 0);

        MovementUp();
        MovementDown();
        MovementRight();
        MovementLeft();
        MovementUpRight();
        MovementUpLeft();
        MovementDownRight();
        MovementDownLeft();
    }

    private void MovementLeft()
    {
        if (left)
        {
            direction.x = -1;
            rigid.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }
    }

    private void MovementRight()
    {
        if (right)
        {
            direction.x = 1;
            rigid.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }
    }   

    private void MovementDown()
    {
        if (down)
        {
            direction.z = -1;
            rigid.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }
    }

    private void MovementUp()
    {
        if (up)
        {
            direction.z = 1;
            rigid.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }
    }

    private void MovementUpRight()
    {
        if (upRight)
        {
            direction.x = 1;
            direction.z = 1;
            rigid.MovePosition(transform.position + (direction * multiDirectionSpeed * Time.deltaTime));
        }
    }

    private void MovementUpLeft()
    {
        if (upLeft)
        {
            direction.x = -1;
            direction.z = 1;
            rigid.MovePosition(transform.position + (direction * multiDirectionSpeed * Time.deltaTime));
        }
    }

    private void MovementDownRight()
    {
        if (downRight)
        {
            direction.x = 1;
            direction.z = -1;
            rigid.MovePosition(transform.position + (direction * multiDirectionSpeed * Time.deltaTime));
        }
    }

    private void MovementDownLeft()
    {
        if (downLeft)
        {
            direction.x = -1;
            direction.z = -1;
            rigid.MovePosition(transform.position + (direction * multiDirectionSpeed * Time.deltaTime));
        }
    }

    public void EnableMovemetUp()
    {
        up = true;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void DisableMovemetUp()
    {
        up = false;
    }

    public void EnableMovemetDown()
    {
        down = true;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    public void DisableMovemetDown()
    {
        down = false;
    }

    public void EnableMovemetRight()
    {
        right = true;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
    }

    public void DisableMovemetRight()
    {
        right = false;
    }

    public void EnableMovemetLeft()
    {
        left = true;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
    }

    public void DisableMovemetLeft()
    {
        left = false;
    }

    public void EnableMovemetUpLeft()
    {
        upLeft = true;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 315, 0));
    }

    public void DisableMovemetUpLeft()
    {
        upLeft = false;
    }

    public void EnableMovemetUpRight()
    {
        upRight = true;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));
    }

    public void DisableMovemetUpRight()
    {
        upRight = false;
    }

    public void EnableMovemetDownLeft()
    {
        downLeft = true;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 225, 0));
    }

    public void DisableMovemetDownLeft()
    {
        downLeft = false;
    }

    public void EnableMovemetDownRight()
    {
        downRight = true;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 135, 0));
    }

    public void DisableMovemetDownRight()
    {
        downRight = false;
    }
}
