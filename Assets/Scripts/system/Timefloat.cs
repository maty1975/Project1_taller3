using UnityEngine;
using TMPro;

public class Timefloat : MonoBehaviour
{
    TextMesh textime;

    private void Awake()
    {
        textime = GetComponentInChildren<TextMesh>(); // Obtener el componente TextMesh
    }

    private void Start()
    {
        // Suscribe el m�todo ActualizarTiempo al evento OnTiempoAgregado del Timer
        Timer.OnTiempoAgregado += ActualizarTiempo;
    }

    // M�todo para actualizar el texto con el tiempo agregado
    private void ActualizarTiempo(int tiempoAgregado)
    {
        // Verificar si el componente TextMesh es nulo antes de intentar acceder a �l
        if (textime != null)
        {
            // Mostrar el tiempo agregado en el texto
            textime.text = "+" + tiempoAgregado + " seconds";
        }
    }

    public void autodestruccion()
    {
        // Asegurarse de que el objeto no ha sido destruido antes de llamar a Destroy
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
