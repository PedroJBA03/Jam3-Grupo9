using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrawMove : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movementX = -1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movementX = 1;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            movementX = 0;
        }
    }

    private void VerticalMove()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movementY = 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movementY = -1;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            movementY = 0;
        }
    }

    private void Take()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            take = true;
            Debug.Log("Jugador 2 agarra");

        }
        else take = false;
    }

}
