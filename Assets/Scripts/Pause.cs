using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; // Importa el espacio de nombres necesario
public class Pause : MonoBehaviour
{
    public KeyCode botonpausa = KeyCode.Escape;
    public GameObject menuPausa;
    public GameObject menuOpciones;
    public UnityEvent Esta_pausado, Esta_reanudado;
    private bool estaPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(botonpausa))
        {
            if (estaPausado)
            {
                Reanudar();
                Esta_reanudado.Invoke();
            }
            else
            {
                Pausar();
                Esta_pausado.Invoke();
            }
        }
    }

    void Pausar()
    {
        Time.timeScale = 0;
        menuPausa.SetActive(true);
        estaPausado = true;
    }

    public void Reanudar()
    {
        Time.timeScale = 1;
        menuPausa.SetActive(false);
        estaPausado = false;
    }

    public void MostrarMenuOpciones()
    {
        menuOpciones.SetActive(true);
    }
    public void NoMostrarMenuOpciones()
    {
        menuOpciones.SetActive(false);
    }

    public void tiempo_normal()
    {
        Time.timeScale = 1;
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("El juego se reiniciar�...");
    }
}
