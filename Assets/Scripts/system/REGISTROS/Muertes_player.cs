using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Muertes_player : MonoBehaviour
{
    public TextMeshProUGUI T_cant_muertes;
    public int Muertes_totales;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void aumentar_muerte()
    {
        Muertes_totales++;
    }

    public void t_mostrar_muertes()
    {
        T_cant_muertes.text = Muertes_totales.ToString();
    }
}
