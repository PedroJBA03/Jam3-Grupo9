using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{
    [SerializeField] private GameObject CorrectPanel;

    [SerializeField] private GameObject CafeWin;
    [SerializeField] private GameObject EmpanadaWn;

    public List<GameObject> questions;

    private GameObject lastQuestions;

    [SerializeField] private Slider slider;
    public float conquistar;

    void Start()
    {
        CorrectPanel.SetActive(false);
        CafeWin.SetActive(false);
        EmpanadaWn.SetActive(false);
        conquistar = 50.0f;
        foreach (GameObject obj in questions)
        {
            obj.SetActive(false);
        }

        
    }

    void Update()
    {
        slider.value = conquistar/100;

        if (conquistar == 0)
        {
            CafeWin.SetActive(true);
            CorrectPanel.SetActive(false);
        }
        if (conquistar == 100)
        {
            EmpanadaWn.SetActive(true);
            CorrectPanel.SetActive(false);
        }
    }

    public void ActiveQuestions()
    {
        int randomIndex = Random.Range(0, questions.Count);
        lastQuestions = questions[randomIndex];
        lastQuestions.SetActive(true);
    }

    public void RemoveLastQuestions()
    {
        if (lastQuestions != null)
        {
            questions.Remove(lastQuestions);
            lastQuestions.SetActive(false);
            lastQuestions = null;
        }
    }

    public void CorrectAnswer()
    {
        CorrectPanel.SetActive(true);
        RemoveLastQuestions(); 
        Time.timeScale = 0;
    }

    public void NextQuestions()
    {
        CorrectPanel.SetActive(false);
        Time.timeScale = 1f;
        ActiveQuestions();
    }
}
