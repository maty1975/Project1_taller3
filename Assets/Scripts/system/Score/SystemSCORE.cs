using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; // Para manejar la imagen de la barra de tiempo de combo
using TMPro;

public class SystemSCORE : MonoBehaviour
{
    public int score = 0; // Variable para almacenar el puntaje
    public int pointsPerEvent = 100; // Cantidad de puntos que se sumarán en cada evento
    public int pointsPerFlag = 300;
    public static int comboMultiplier = 1; // Multiplicador de combo inicial
    public int maxComboMultiplier = 5; // Máximo multiplicador de combo
    public float comboTimeLimit = 5f; // Límite de tiempo para mantener el combo
    public Image comboTimerImage; // Imagen para mostrar el tiempo restante del combo

    private float comboTimer = 0f; // Temporizador de combo
    private bool isComboActive = false; // Bandera para saber si el combo está activo

    public UnityEvent onScoreChange; // Evento que se dispara cuando cambia el puntaje
    public UnityEvent double_Combo;
    public UnityEvent Triple_Combo;
    public UnityEvent quadra_Combo;
    public UnityEvent quintu_Combo;
    public UnityEvent end_Combo;

    internal Action<int> onAddPoint;

    // Método para sumar puntos al puntaje y gestionar el combo
    public void AddPoints()
    {


        // Añadir puntos base
        score += pointsPerEvent * comboMultiplier;

        // Incrementar el multiplicador de combo si estamos dentro del límite de tiempo del combo
        if (comboTimer > 0)
        {
            comboMultiplier = Mathf.Min(comboMultiplier + 1, maxComboMultiplier);

            if (comboMultiplier == 2)
            {
                double_Combo.Invoke();
            }
            else if (comboMultiplier == 3)
            {
                Triple_Combo.Invoke();
            }
            else if (comboMultiplier == 4)
            {
                quadra_Combo.Invoke();
            }
            else if (comboMultiplier == 5)
            {
                quintu_Combo.Invoke();
            }
        }
        else
        {
            // Reiniciar el multiplicador de combo si no estamos dentro del límite de tiempo del combo
            comboMultiplier = 1;
        }

        // Reiniciar el temporizador de combo
        comboTimer = comboTimeLimit;
        isComboActive = true;

        // Disparar evento de cambio de puntaje
        onScoreChange.Invoke();
    }

    public void AddPointsForFlag()
    {
        // Añadir puntos por bandera
        score += pointsPerFlag;

        // Disparar evento de cambio de puntaje
        onScoreChange.Invoke();
    }

    private void Update()
    {
        // Actualizar el temporizador de combo
        if (comboTimer > 0)
        {
            comboTimer -= Time.deltaTime;

            // Actualizar la imagen del temporizador de combo (fillAmount)
            if (comboTimerImage != null)
            {
                comboTimerImage.fillAmount = comboTimer / comboTimeLimit;
            }
        }
        else if (isComboActive)
        {
            // Si el combo ha terminado, invocar el evento y resetear la bandera
            end_Combo.Invoke();
            isComboActive = false;
        }
    }

    public void Combo_plus(int number_combo)
    {
        comboMultiplier = number_combo;
        comboTimer = comboTimeLimit + 10;
        maxComboMultiplier = number_combo;
        isComboActive = true;
    }



    public void actualizar_puntaje_entext(TextMesh textmesh)
    {
        textmesh.text = score.ToString();
    }

    public void actualizar_puntaje_entextPRO(TextMeshProUGUI textmesh)
    {
        textmesh.text = score.ToString();
    }
}
