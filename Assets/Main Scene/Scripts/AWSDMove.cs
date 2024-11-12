using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWSDMove : MonoBehaviour
{
    public float speed;

    float movementX;
    float movementY;

    bool take = false;

    Rigidbody2D Rb;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

        movementX = 0;
        movementY = 0;
    }

    void Update()
    {
        Rb.velocity = new Vector2(movementX * speed * Time.deltaTime, movementY * speed * Time.deltaTime);

        HorizontalMove();
        VerticalMove();
        Take();

    }

    private void HorizontalMove()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movementX = -1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            movementX = 1;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            movementX = 0;
        }
    }

    private void VerticalMove()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movementY = 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            movementY = -1;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            movementY = 0;
        }
    }

    private void Take()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            take = true;
            Debug.Log("Jugador 1 agarra");
        } else take = false;
    }
}
