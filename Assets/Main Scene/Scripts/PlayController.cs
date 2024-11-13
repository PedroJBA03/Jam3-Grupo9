using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float conquistar;

    void Start()
    {
        conquistar = 50.0f;
    }

    void Update()
    {
        slider.value = conquistar/100;
    }
}
