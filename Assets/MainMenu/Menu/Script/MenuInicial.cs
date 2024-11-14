using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour

{
    [SerializeField] private GameObject Instrucciones;
    [SerializeField] private GameObject PanelCreditos;

    private void Start()
    {
        Instrucciones.SetActive(false);
        PanelCreditos.SetActive(false);
    }
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    

    }

   public void Instruccion()
   {
        Instrucciones.SetActive(true);

    }
   

    public void Creditos()
    {
        PanelCreditos.SetActive(true);
    }
    public void CerrarPanel()
    {
        Instrucciones.SetActive(false);
        PanelCreditos.SetActive(false);
    }
    }
