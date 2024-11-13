using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{

    void Start()
    {
        float randomX = Random.Range(-2f, 7f);
        float randomY = Random.Range(-2.5f, 2.75f);

        transform.position = new Vector3(randomX, randomY, 0);
    }

}
