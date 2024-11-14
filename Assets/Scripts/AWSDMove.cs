using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AWSDMove : MonoBehaviour
{
    public bool CorAnsT;

    public float speed;
    public float run;

    bool fail = true;

    float movementX;
    float movementY;

    float clampedX;
    float clampedY;

    Rigidbody2D Rb;

    [SerializeField] private score1 scoreone;

    private PlayController controladorJuego;

    void Start()
    {
        CorAnsT = false;

        transform.position = new Vector3(-3.8f, -3.8f, 0);

        Rb = GetComponent<Rigidbody2D>();

        movementX = 0;
        movementY = 0;
        run = 0f;

        controladorJuego = GameObject.FindObjectOfType<PlayController>();

    }

    void Update()
    {
        Rigid();

        HorizontalMove();
        VerticalMove();

        MoveLimit();

        Confirmacion();
        PlayQ();
    }

    private void Rigid()
    {
        Rb.velocity = new Vector2(movementX * speed * run, movementY * speed * run);
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
        clampedX = Mathf.Clamp(transform.position.x, -3.8f, 6.9f);
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
        clampedY = Mathf.Clamp(transform.position.y, -4.1f, 3.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CoAnswer"))
        {
            scoreone.SumarPuntosOne(1);
            Debug.Log("Punto player 1");
            if (controladorJuego != null)
            {
                controladorJuego.conquistar += 10f;
            }
            controladorJuego.CorrectAnswer();
        }
        if (collision.CompareTag("InAnswer") && fail==true)
        {
            if (scoreone.scoreone > 0)
            {
                scoreone.SumarPuntosOne(-1);
                Debug.Log("Player 1 pierde punto");
            }
            StartCoroutine(InitialPos());
        }
    }

    IEnumerator InitialPos()
    {
        fail = false;
        speed = 0f;
        yield return new WaitForSeconds(3.0f);
        transform.position = new Vector3(-3.8f, -3.8f, 0);
        yield return new WaitForSeconds(2.0f);
        speed = 3f;
        fail = true;
    }

    private void PlayQ()
    {
        if (controladorJuego != null && controladorJuego.playQ == true)
        {
            run = 1;
        }
    }

    private void Confirmacion()
    {
        if (controladorJuego.confir == true)
        {
            transform.position = new Vector3(-3.8f, -3.8f, 0);
        }
    }
}
