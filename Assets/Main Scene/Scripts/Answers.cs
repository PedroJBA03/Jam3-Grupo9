using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public bool theCorrect;

    void Start()
    {
        float randomX = Random.Range(-2.8f, 7.25f);
        float randomY = Random.Range(-2.9f, 2.8f);

        transform.position = new Vector3(randomX, randomY, 0);
    }

}
