using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anwers2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(4.5f, 7f);
        float randomY = Random.Range(-2.5f, 2.75f);

        transform.position = new Vector3(randomX, randomY, 0);
    }

}
