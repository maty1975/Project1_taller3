using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SystemZone : MonoBehaviour
{
    public Bandera[] banderas;
    public GameObject puertaEntrada;
    public GameObject puertaSalida;
    public int cantidadBanderasRequeridas = 3; // Cantidad de banderas que el jugador debe recolectar
    [SerializeField] private int banderasRecolectadas = 0;
    public UnityEvent Al_activar_puerta;
    public UnityEvent Al_desactivar_puerta;
    void Awake()
    {
        //ActualizarEstadoPuertas();
        // Suscribirse al evento de recolección de cada bandera
        foreach (var bandera in banderas)
        {
            bandera.OnRecolectar.AddListener(RecolectarBandera);
        }
    }

    void ActualizarEstadoPuertas()
    {
        bool puertasCerradas = banderasRecolectadas < cantidadBanderasRequeridas;
        //puertaEntrada.SetActive(puertasCerradas);
        //puertaSalida.SetActive(puertasCerradas);

        // Invocar el evento correspondiente según el estado de las puertas
        if (puertasCerradas)
        {
            Al_activar_puerta.Invoke();
        }
        else
        {
            Al_desactivar_puerta.Invoke();
        }
    }

    public void RecolectarBandera()
    {
        banderasRecolectadas++;
        ActualizarEstadoPuertas();
    }

    public void ResetearBanderas()
    {
        foreach (var bandera in banderas)
        {
            bandera.recolectada = false;
        }
        banderasRecolectadas = 0;
        ActualizarEstadoPuertas();
    }
    public void puertas()
    {
        ActualizarEstadoPuertas();
    }
}
