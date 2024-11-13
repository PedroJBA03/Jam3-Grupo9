using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class score2 : MonoBehaviour
{
    private int scoretwo;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = scoretwo.ToString();
    }

    public void SumarPuntosTwo(int puntosEntradaTwo)
    {
        scoretwo += puntosEntradaTwo;
    }

}
