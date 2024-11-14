using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anwers1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(1.5f, 4f);
        float randomY = Random.Range(-2.5f, 2.4f);

        transform.position = new Vector3(randomX, randomY, 0);
    }

}
