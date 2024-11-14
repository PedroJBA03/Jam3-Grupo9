using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsStates : MonoBehaviour
{
    [SerializeField] private GameObject ButtomPause;
    [SerializeField] private GameObject MenuPause;

    private void Start()
    {
        Time.timeScale = 1f;
        ButtomPause.SetActive(true);
        MenuPause.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        ButtomPause.SetActive(false);
        MenuPause.SetActive(true);
    } 

    public void Resume()
    {
        Time.timeScale = 1f;
        ButtomPause.SetActive(true);
        MenuPause.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
