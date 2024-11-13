using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score1 : MonoBehaviour
{
    private int scoreone;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = scoreone.ToString();
    }

    public void SumarPuntosOne(int puntosEntradaOne)
    {
        scoreone += puntosEntradaOne;
    }
}
