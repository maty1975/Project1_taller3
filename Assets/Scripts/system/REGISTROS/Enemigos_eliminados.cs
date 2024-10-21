using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemigos_eliminados : MonoBehaviour
{
    public TextMeshProUGUI t_enemigos_eliminados;
    public int cantidad_enemigos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sumar_cantidad()
    {
        cantidad_enemigos++;
    }

    public void T_mostrar_muertes_enemigos()
    {
        t_enemigos_eliminados.text = cantidad_enemigos.ToString();
    }
}
