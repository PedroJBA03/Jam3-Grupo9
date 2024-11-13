using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AWSDMove : MonoBehaviour
{

    public float speed;

    float movementX;
    float movementY;

    float clampedX;
    float clampedY;

    Rigidbody2D Rb;

    [SerializeField] private score1 scoreone;

    private PlayController controladorJuego;

    void Start()
    {
        transform.position = new Vector3(-3.8f, -3.8f, 0);

        Rb = GetComponent<Rigidbody2D>();

        movementX = 0;
        movementY = 0;
        speed = 800f;

        controladorJuego = GameObject.FindObjectOfType<PlayController>();

    }

    void Update()
    {
        Rigid();

        HorizontalMove();
        VerticalMove();

        MoveLimit();
    }

    private void Rigid()
    {
        Rb.velocity = new Vector2(movementX * speed * Time.deltaTime, movementY * speed * Time.deltaTime);
    }

    private void MoveLimit()
    {
        transform.position = new Vector2(clampedX, clampedY);
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
        clampedX = Mathf.Clamp(transform.position.x, -3.8f, 7.25f);
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
        clampedY = Mathf.Clamp(transform.position.y, -3.9f, 3.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CoAnswer"))
        {
            scoreone.SumarPuntosOne(1);
            Debug.Log("Punto player 1");
            if (controladorJuego != null)
            {
                controladorJuego.conquistar += 8.33f;
            }
        }
        if (collision.CompareTag("InAnswer"))
        {
            scoreone.SumarPuntosOne(-1);
            Debug.Log("Player 1 pierde punto");
            StartCoroutine(InitialPos());
        }
    }

    IEnumerator InitialPos()
    {
        speed = 0f;
        yield return new WaitForSeconds(3.0f);
        transform.position = new Vector3(-3.8f, -3.8f, 0);
        speed = 800f;
    }
}
