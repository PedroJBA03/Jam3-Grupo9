using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{
    [SerializeField] private GameObject CorrectPanel;

    [SerializeField] private GameObject CafeWin;
    [SerializeField] private GameObject EmpanadaWn;

    [SerializeField] private GameObject ButtonIn;

    public List<GameObject> questions;

    private GameObject lastQuestions;

    [SerializeField] private Slider slider;
    public float conquistar;

    public bool playQ = false;
    public bool confir = false;
    private bool hasPlayedWinSound = false; // Para evitar reproducir el sonido varias veces

    void Start()
    {
        CorrectPanel.SetActive(false);
        CafeWin.SetActive(false);
        EmpanadaWn.SetActive(false);
        ButtonIn.SetActive(true);
        conquistar = 50.0f;
        foreach (GameObject obj in questions)
        {
            obj.SetActive(false);
        }

        
    }

    void Update()
    {
        slider.value = conquistar / 100;

        if (conquistar == 0 && !hasPlayedWinSound)
        {
            CafeWin.SetActive(true);
            CorrectPanel.SetActive(false);
            
            // Reproduce el sonido de victoria para el equipo rojo
            AudioManager.Instance.PlayRedTeamWinSFX();
            hasPlayedWinSound = true;
            StartCoroutine(ComeBack());
        }
        else if (conquistar == 100 && !hasPlayedWinSound)
        {
            EmpanadaWn.SetActive(true);
            CorrectPanel.SetActive(false);
            
            // Reproduce el sonido de victoria para el equipo azul
            AudioManager.Instance.PlayBlueTeamWinSFX();
            hasPlayedWinSound = true;
            StartCoroutine(ComeBack());
        }
    }

    public void ActiveQuestions()
    {
        int randomIndex = Random.Range(0, questions.Count);
        lastQuestions = questions[randomIndex];
        lastQuestions.SetActive(true);
        ButtonIn.SetActive(false);
        playQ = true;
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
        AudioManager.Instance.PlayWinSFX();
        RemoveLastQuestions();
        confir = true;
        Time.timeScale = 0;
    }

    public void NextQuestions()
    {
        CorrectPanel.SetActive(false);
        Time.timeScale = 1f;
        ActiveQuestions();
        confir = false;
    }

    IEnumerator ComeBack()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(0);
    }
}
