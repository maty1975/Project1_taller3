using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI hptext;
    public TextMeshProUGUI Scoretext_endgame;
    public VariableInt hp;
    
    private void Update()
    {
        UpdateHealthText();
    }

    public void UpdateHealthText()
    {
        hptext.text = hp.valor.ToString();
    }


    // Función para actualizar el puntaje en la UI
    public void ActualizarPuntaje()
    {
        // Encuentra el componente SystemSCORE y actualiza el texto con el puntaje obtenido
        Scoretext_endgame.text = "" + FindObjectOfType<SystemSCORE>().score.ToString();
    }


}
